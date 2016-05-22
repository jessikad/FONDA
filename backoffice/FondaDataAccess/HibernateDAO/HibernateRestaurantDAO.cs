﻿using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernateRestaurantDAO : HibernateNounBaseEntityDAO<Restaurant>, IRestaurantDAO
    {
        FactoryDAO.FactoryDAO _facDAO = FactoryDAO.FactoryDAO.Intance;

		/// <summary>
        /// Devuelve todos los restaurantes
        /// </summary>
        /// <returns>Una lista de restaurantes</returns>
        public IList<Restaurant> GetAll()
        {
            return FindAll();
        }

        /// <summary>
        /// Metodo para devolver todos los restaurantes 
        /// que se encuentran en una zona
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public IList<Restaurant> findByZone(Zone zone)
        {
            ICriterion criterion = Expression.Eq("Zone", zone);
            return (FindAll(criterion));
		}
		
        /// <summary>
        /// Genera un nuevo Restaurante a partir de los datos suministrados por el usuario
        /// </summary>
        /// <param name="Name">Nombre del Restaurante</param>
        /// <param name="Logo">Logo del Restaurante</param>
        /// <param name="Nationality">Nacionalidad</param>
        /// <param name="Rif">Rif del Restaurante</param>
        /// <param name="Address">Direccion fisica del Restaurante</param>
        /// <param name="Category">Tipo de comida del Restaurante</param>
        /// <param name="Currency">Tipo de moneda del Restaurante</param>
        /// <param name="Zone">Ubicacion del Restaurante</param>
        /// <param name="Long">Longitud para Coordenada</param>
        /// <param name="Lat">Latitud para Coordenada</param>
        /// <param name="OpeningTime">Hora de apertura</param>
        /// <param name="ClosingTime">Hora de cierre</param>
        /// <param name="Days">Dias laborables</param>
        /// <returns></returns>
        public Restaurant GenerateRestaurant(string Name, string Logo, char Nationality, string Rif, string Address,
                string Category, string Currency, string Zone, double Long, double Lat,
                TimeSpan OpeningTime, TimeSpan ClosingTime, bool[] Days)
        {

            IRestaurantCategoryDAO _restcatDAO = _facDAO.GetRestaurantCategoryDAO();
            ICurrencyDAO _currencyDAO = _facDAO.GetCurrencyDAO();
            IZoneDAO _zoneDAO = _facDAO.GetZoneDAO();
            IScheduleDAO _scheduleDAO = _facDAO.GetScheduleDAO();


            Coordinate coordinate = new Coordinate();
            coordinate.Latitude = Lat;
            coordinate.Longitude = Long;

            Restaurant restaurant = new Restaurant();
            restaurant.Name = Name;
            restaurant.Logo = Logo;
            restaurant.Nationality = Nationality;
            restaurant.Ssn = Rif;
            restaurant.Address = Address;
            restaurant.RestaurantCategory = _restcatDAO.GetRestaurantCategory(Category);
            restaurant.Currency = _currencyDAO.GetCurrency(Currency);
            restaurant.Zone = _zoneDAO.GetZone(Zone);
            restaurant.Coordinate = coordinate;
            restaurant.Schedule = _scheduleDAO.GetSchedule(OpeningTime, ClosingTime, Days);
            restaurant.Status = _facDAO.GetActiveSimpleStatus();

            return restaurant;


        }

        /// <summary>
        /// Modifica un Restaurante
        /// </summary>
        /// <param name="idRestaurant">Id del Restaurante a modificar</param>
        /// <param name="newRestaurant">Datos a modificar del Restaurante</param>
        /// <returns>Restaurante resultante</returns>
        public Restaurant ModifyRestaurant(int idRestaurant, Restaurant newRestaurant)
        {
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

            // Consigue el Restaurante a modificar en la Base de Datos
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(idRestaurant);

            // Cambia los valores suministrados por el usuario
            _restaurant.Name = newRestaurant.Name;
            _restaurant.Logo = newRestaurant.Logo;
            _restaurant.Nationality = newRestaurant.Nationality;
            _restaurant.Ssn = newRestaurant.Ssn;
            _restaurant.Address = newRestaurant.Address;
            _restaurant.RestaurantCategory = newRestaurant.RestaurantCategory;
            _restaurant.Currency = newRestaurant.Currency;
            _restaurant.Zone = newRestaurant.Zone;
            _restaurant.Coordinate = newRestaurant.Coordinate;
            _restaurant.Schedule = newRestaurant.Schedule;
            _restaurant.Status = _facDAO.GetActiveSimpleStatus();

            return _restaurant;
        }

        public Restaurant findByTable(Table table)
        {
            ICriteria crit = Session.CreateCriteria(typeof(Restaurant));
            // Inner Join
            crit.CreateAlias("Tables", "sm");
            crit.Add(Restrictions.Eq("sm.Id", table.Id));
            return (Restaurant)crit.List()[0];
        }

        public bool Geoposition(double _latitudUser, double _longitudUser, int _idRestaurant) {
            bool came = false;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();

            // Consigue el Restaurante de la Base de Datos
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            
            Decimal _latitudDecimal= Math.Round(Convert.ToDecimal(_latitudUser), 2);
            Decimal _longitudDecimal = Math.Round(Convert.ToDecimal(_longitudUser), 2);

            Decimal _latitudRestaurantDecimal= Math.Round(Convert.ToDecimal(_restaurant.Coordinate.Latitude), 2);
            Decimal _longitudRestaurantDecimal = Math.Round(Convert.ToDecimal(_restaurant.Coordinate.Longitude), 2);

            if (_latitudRestaurantDecimal == _latitudDecimal && _longitudRestaurantDecimal == _longitudDecimal)
            { 
                came = true;
            }
            return came;
        }

        public bool ValidateHour(int _idRestaurant,DateTime _hour)
        {
            bool valid = true;
            TimeSpan _hourSpan;
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            _hourSpan = _hour.TimeOfDay;
            //_hourSpan = _hourSpan.;
            if (_hourSpan< _restaurant.Schedule.OpeningTime || _hourSpan>_restaurant.Schedule.ClosingTime)
            {
                valid = false;
            }

            return valid;
        }

        public bool ValidateDay(int _idRestaurant, DateTime _date)
        {
            bool valid = false;
            DayOfWeek _day;
            IList<Day> _daysRestaurant;
            string nameDayOfWeek="";
            IRestaurantDAO _restaurantDAO = _facDAO.GetRestaurantDAO();
            com.ds201625.fonda.Domain.Restaurant _restaurant = _restaurantDAO.FindById(_idRestaurant);
            _day = _date.DayOfWeek;
            _daysRestaurant = _restaurant.Schedule.Day;
            if ((int) _day ==7)
            {
                nameDayOfWeek = "Domingo";
            }
            if ((int) _day == 1)
            {
                nameDayOfWeek = "Lunes";
            }
            if ((int) _day == 2)
            {
                nameDayOfWeek = "Martes";
            }
            if ((int)_day == 3)
            {
                nameDayOfWeek = "Miercoles";
            }
            if ((int)_day == 4)
            {
                nameDayOfWeek = "Jueves";
            }
            if ((int)_day == 5)
            {
                nameDayOfWeek = "Viernes";
            }
            if ((int)_day == 3)
            {
                nameDayOfWeek = "Sabado";
            }

            foreach (Day d in _daysRestaurant)
            {
                if (d.Name == nameDayOfWeek)
                    valid = true;
            }

            return valid;
        }

        public IList<Restaurant> findByCategory(RestaurantCategory category)
        {
            ICriterion criterion = Expression.Eq("RestaurantCategory", category);
            return (FindAll(criterion));
        }
    }


}

