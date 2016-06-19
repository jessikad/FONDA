﻿using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using System.Collections.Generic;
using com.ds201625.fonda.Factory;
using com.ds201625.fonda.Tests.DataAccess;
using com.ds201625.fonda.DataAccess.Exceptions;

namespace FondaDataAccessTest
{
    [TestFixture()]
    class FORestaurantFavorite : BaseEntity
    {

        private FactoryDAO _facDAO;
        private ICommensalDAO _commensalDAO;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant1;
        private Commensal _commensal;

        /// <summary>
        /// Void: createCommensal()
        /// Explicación: Instancio el objeto Commensal y le introduzco valores para poder hacer las pruebas.
        /// </summary>

        private void createCommensal()
        {
            _commensal = new Commensal()
            {
                Password = "123456",
                Email = "Commensal10@gmail.com",
                Status = ActiveSimpleStatus.Instance

            };

        }
        /// <summary>
        /// Void: createRestaurant()
        /// Explicación: Instancio el objeto Restaurant y le introduzco valores para poder hacer las pruebas.
        /// </summary>

        private void createRestaurant()
        {
            _restaurant1 = EntityFactory.GetRestaurant();
            _restaurant1.Name = "Tinajero";
            _restaurant1.Logo = "C:/s";
            _restaurant1.Nationality = 'V';
            _restaurant1.Ssn = "123456";
            _restaurant1.Address = "Av. El ejercito con puente de San Juan";
            _restaurant1.Status = ActiveSimpleStatus.Instance;

            Currency _currency = new Currency();
            _currency.Symbol = "C:/s";
            _currency.Name = "Dolares";

            _restaurant1.Currency = _currency;

            Coordinate _coordinate = new Coordinate();
            _coordinate.Latitude = 1;
            _coordinate.Longitude = 4;
            _restaurant1.Coordinate = _coordinate;

            RestaurantCategory _restaurantCategory = EntityFactory.GetCategoryRestaurent();
            _restaurantCategory.Name = "Chinas";
            _restaurant1.RestaurantCategory = _restaurantCategory;
            

            Zone _zone = new Zone();
            _zone.Name = "Caracas";
            _restaurant1.Zone = _zone;

           MenuCategory _menuCategories = new MenuCategory() { Name = "Italiana", Status = DisableSimpleStatus.Instance };
            _restaurant1.MenuCategories = new List<MenuCategory>();
            _restaurant1.MenuCategories.Add(_menuCategories);

            Schedule _schedule = new Schedule();
            _schedule.OpeningTime = new TimeSpan(7, 0, 0);
            _schedule.ClosingTime = new TimeSpan(15, 0, 0);
            _restaurant1.Schedule = _schedule;

            Employee _employee = new Employee()
            {
                Name = "José",
                LastName = "Garcia",
                Ssn = "19932801",
                PhoneNumber = "0414-11-63-457",
                Address = "Direccion de Prueba",
                Gender = 'M',
                BirthDate = Convert.ToDateTime("08/08/1991"),
                Username = "Usuario",
                Status = ActiveSimpleStatus.Instance,
                UserAccount = new UserAccount()
                {
                    Email = "email100@gmail.com",
                    Password = "123",
                    Status = ActiveSimpleStatus.Instance
                },
                Role = new Role() { Name = "Administrador de Sistemas", Descripcion = "Es el administrado" }
            };
           

        }

        private void getCommensalDao()
        {
            getDao();
            if (_commensalDAO == null)
                _commensalDAO = _facDAO.GetCommensalDAO();

        }

        private void getRestaurantDao()
        {
            getDao();
            if (_restaurantDAO == null)
                _restaurantDAO = _facDAO.GetRestaurantDAO();

        }
        /// <summary>
        /// Void: getDao() 
        /// Explicación: Sirve para instanciar la clase Factory.
        /// </summary>
        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }

        /// <summary>
        /// Void: addRestaurantToCommensal()
        /// Explicación: Se pasan dos parametros, un objeto Commensal y un array de Restaurant, se recorre
        /// el array de Restaurant para así ir pasando uno a uno a la funcion AddFavoriteRestaurant() que se
       /// encuentra en la clase Commensal y así introducirlo en el objeto Commensal.
        /// </summary>
        /// <param name="_commensal"></param>
        /// <param name="_restarants"></param>

        public static void addRestaurantToCommensal
            (Commensal _commensal, params Restaurant[] _restarants)
        {

            foreach (var restaurant in _restarants)
            {

                _commensal.AddFavoriteRestaurant(restaurant);

            }

        }
        /// <summary>
        /// Void: removeRestaurantToCommensal()
        /// Explicación: Se pasan dos parametros, un objeto Commensal y un array de Restaurant. Se recorre
        /// el array de Restaurant para así ir pasando uno a uno a la funcion RemoveFavoriteRestaurant() que se
        /// encuenta en la clase Commensal y así poder sacarlo del objeto Comensal.
        /// </summary>
        /// <param name="commensal"></param>
        /// <param name="restarants"></param>

        public static void removeRestaurantToCommensal
           (Commensal commensal, params Restaurant[] restarants)
        {

            foreach (var restaurant in restarants)
            {
                commensal.RemoveFavoriteRestaurant(restaurant);
            }

        }

        /// <summary>
        /// Procedimiento: restaurantFavoriteSave()
        /// Explicación: Esta Prueba unitaria es para insertar un comensal en la tabla USER_ACCOUNT y restaurante
        /// en la tabla RESTAURANT, además de eso inserta en el N:N de ambas para asi simular que un comensal elige
        /// un restaurante como favorito. Se pasan dos funciones que instancian dos objetos, uno de restaurante y otro
        /// de comensal, se hacen las respectivas pruebas y luego se guarda una lista de restarantes en la lista de
        /// commensal para asi aplicarle Save() e insertar.
        /// NOTA: esta prueba fue por falta de código de los otros modulos.
        /// </summary>

        [Test()]
        public void restaurantFavoriteSave()
        {
            getCommensalDao();
            getRestaurantDao();
            createCommensal();
            createRestaurant();
            Assert.NotNull(_commensal);
            Assert.NotNull(_restaurant1);
            addRestaurantToCommensal(_commensal, _restaurant1);
            _commensalDAO.Save(_commensal);

        }

        /// <summary>
        /// Void: addRestaurantFavoriteById()
        /// Explicación: En esta prueba unitaria, buscamos por id con la funcion FindById() de la interface de
        /// IRestaurantDAO Y ICommensalDAO para asi traer sus respectivos objetos y guardarlo en el N:N de
        /// RESTAURANT_COMMENSAL
        /// </summary>

        [Test()]
        public void addRestaurantFavoriteById()
        {
            getRestaurantDao();
            getCommensalDao();
            Restaurant _restaurantId1 = _restaurantDAO.FindById(1);
            Restaurant _restaurantId2 = _restaurantDAO.FindById(2);

            Assert.NotNull(_restaurantId1);
            Assert.NotNull(_restaurantId2);
            Assert.AreEqual(_restaurantId1.Id, 1);
            Assert.AreEqual(_restaurantId2.Id, 2);
            Assert.AreNotSame(_restaurantId1, _restaurantId2);
            Assert.AreNotEqual(_restaurantId1.Id, 0);
            Assert.AreNotEqual(_restaurantId2.Id, 0);

            Commensal _commensalId1 = (Commensal)_commensalDAO.FindById(8);

            Assert.NotNull(_commensalId1);
            Assert.AreEqual(_commensalId1.Id, 2);
            Assert.AreNotEqual(_commensalId1.Id, 0);

            addRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
            _commensalDAO.Save(_commensalId1);
        }

        /// <summary>
        /// Void: deleteRestaurantFavoriteById()
        /// Explicación: En esta prueba unitaria, buscamos por id con la funcion FindById() de la interface de
        /// IRestaurantDAO Y ICommensalDAO para asi traer sus respectivos objetos y eliminarlos en el N:N de
        /// RESTAURANT_COMMENSAL
        /// </summary>

        [Test()]
        public void deleteRestaurantFavoriteById()
        {
            getRestaurantDao();
            getCommensalDao();


            Restaurant _restaurantId1 = _restaurantDAO.FindById(4);
            Restaurant _restaurantId2 = _restaurantDAO.FindById(5);

            Assert.NotNull(_restaurantId1);
            Assert.NotNull(_restaurantId2);
            Assert.AreEqual(_restaurantId1.Id, 4);
            Assert.AreEqual(_restaurantId2.Id, 5);
            Assert.AreNotSame(_restaurantId1, _restaurantId2);
            Assert.AreNotEqual(_restaurantId1.Id, 0);
            Assert.AreNotEqual(_restaurantId2.Id, 0);

            Commensal _commensalId1 = (Commensal)_commensalDAO.FindById(8);

            Assert.NotNull(_commensalId1);
            Assert.AreEqual(_commensalId1.Id, 8);
            Assert.AreNotEqual(_commensalId1.Id, 0);


            removeRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
            _commensalDAO.Save(_commensalId1);

        }

        /// <summary>
        /// prueba encontrar comensal por email
        /// </summary>
   /*   [Test]
        public void FindCommensalByEmailTest()
        {
            UserAccount answer = new UserAccount();
            _commensal.Id = 1;
            answer = _commensalDAO.FindByEmail("prueba@gmail.com");
            Assert.AreEqual(answer.Id, _commensal.Id);

        }
    * 
     /// <summary>
        /// prueba guardar restaurant favorito dao
        /// </summary>
      /*[Test]
        [ExpectedException(typeof(SaveEntityFondaDAOException))]
         public void CreateFavoriteRestaurantCommandNullReferenceTest()
        {
            addRestaurantToCommensal(_commensal, _restaurant1);
            _commensalDAO.Save(_commensal);
            Assert.Null(_commensal);
            Assert.Null(_restaurant1);
        }
         /// <summary>
        /// prueba borrar restaurant favorito dao
        /// </summary>
      [Test]
        [ExpectedException(typeof(DeleteFondaDAOException))]
        public void DeleteteRestaurantCommandNullReferenceTest()
        {
            getRestaurantDao();
            getCommensalDao();

            Restaurant _restaurantId1 = _restaurantDAO.FindById(20);
            Restaurant _restaurantId2 = _restaurantDAO.FindById(25);
            Commensal _commensalId1 = (Commensal)_commensalDAO.FindById(20);
            removeRestaurantToCommensal(_commensalId1, _restaurantId1, _restaurantId2);
            _commensalDAO.Save(_commensal);
            Assert.Null(_commensalId1);
            Assert.Null(_restaurantId1);
        }
      */
        /// <summary>
        /// prueba excepcion, referencia nula al buscar un commensal por email
        /// </summary>
          [Test]
          [ExpectedException(typeof(NullReferenceException))]
        public void FindCommensalByEmailNullReferenceTest()
        {
            Assert.Null(_commensalDAO.FindByEmail("restaurantesFinos@hotmail.com"));
        }
          /// <summary>
          /// prueba excepcion, referencia nula al buscar un commensal por id
          /// </summary>
          [Test]
          [ExpectedException(typeof(NullReferenceException))]
          public void CommensalDaoFindByNullReferenceTest()
          {
              Assert.Null(_commensalDAO.FindById(18));
          }
      
    }

    }