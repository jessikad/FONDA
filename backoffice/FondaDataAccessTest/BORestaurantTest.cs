﻿using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FondaDataAccessTest
{
    [TestFixture]
    public class BORestaurantTest
    {
        private FactoryDAO _facDAO;
        private IRestaurantDAO _restaurantDAO;
        private Restaurant _restaurant;
        Restaurant _newRestaurant;
        IList<Restaurant> _restaurantList;
        private int _restaurantId;
        private IDishDAO _dishDAO;
        TimeSpan OT;
        TimeSpan CT;
        bool[] days;

        #region 3era Entrega - Restaurante
        [SetUp]
        public void init()
        {
            _facDAO = FactoryDAO.Intance;
            _restaurantDAO = _facDAO.GetRestaurantDAO();
            _newRestaurant = new Restaurant();
            OT = TimeSpan.Parse("11:00:00");
            CT = TimeSpan.Parse("22:00:00");
            days = new bool[] { true, true, true, true, true, true, true };
        }

        [TearDown]
        public void clean()
        {
            _facDAO = null;
        }

        [Test]
        public void generateRestaurantTest()
        {
            _newRestaurant = _restaurantDAO.GenerateRestaurant("Mamma Mia", "C:/", 'V', "123458",
                "Montalban", "China", "Bolivar Fuerte", "Montalban", 10.1, 10.2, OT, CT, days);
            _restaurant = new Restaurant();
            _restaurant.Name = "Mamma Mia";
            //Assert.NotNull(_newRestaurant);
            Assert.AreEqual(_restaurant.Name, _newRestaurant.Name);

        }

        [Test]
        public void modifyRestaurantTest()
        {
            _newRestaurant = _restaurantDAO.GenerateRestaurant("Mamma Mia", "C:/", 'V',"123458",
                "Montalban", "China", "Bolivar Fuerte", "Montalban", 10.1, 10.2, OT, CT, days);
            _restaurant = _restaurantDAO.ModifyRestaurant(2, _newRestaurant);
            Assert.AreEqual("Mamma Mia", _restaurant.Name);
        }

        [Test]
        public void getAllTest()
        {
            //_restaurantList = _restaurantDAO.GetAll();
            IList<Restaurant> _listaRestaurant = _restaurantDAO.GetAll();
            Assert.NotNull(_listaRestaurant);
            //Assert.AreEqual(_restaurantList[0].Name, "El Mundo del Pollo");
        }

        [ExpectedException(typeof(FindAllFondaDAOException))]
        [Test]
        public void getFindAllFondaDAOException()
        {
            _restaurantList = (List<Restaurant>)_restaurantDAO.GetAll();
        }

        #endregion


        /*  [Test]
          public void RestaurantTest()
          {

              generateRestaurant();
              restaurantAssertions();
          }


          private void generateRestaurant(bool edit = false)
          {
              getDao();
              if (_restaurant != null)
                  return;

              if ((edit & _restaurant == null) | _restaurant == null)
                  _restaurant = new Restaurant();
              _restaurant.Name = "Mundo de la Carne";
              _restaurant.Logo = "C:/";
              _restaurant.Nationality = 'V';
              _restaurant.Ssn = "123457";
              _restaurant.Address = "Av. Paéz";
              _restaurant.Status = _facDAO.GetActiveSimpleStatus();

              Currency _currency = new Currency();
              _currency.Name = "Euro2";
              _currency.Symbol = "€";
              _restaurant.Currency = _currency;

              Coordinate _coordinate = new Coordinate();
              _coordinate.Latitude = 10.494965;
              _coordinate.Longitude = -66.925364;
              _restaurant.Coordinate = _coordinate;

              RestaurantCategory _restaurantCategory = new RestaurantCategory();
              _restaurantCategory.Name = "China2";
              _restaurant.RestaurantCategory = _restaurantCategory;

               Zone _zone = new Zone();
               _zone.Name = "Caracas";
               _restaurant.Zone = _zone;

              MenuCategory _menuCategories = new MenuCategory() { Name = "Italiana", Status = _facDAO.GetActiveSimpleStatus() };
              _restaurant.MenuCategories = new List<MenuCategory>();
              _restaurant.MenuCategories.Add(_menuCategories);

              Schedule _schedule = new Schedule();
              _schedule.OpeningTime = new TimeSpan(11, 0, 0);
              _schedule.ClosingTime = new TimeSpan(22, 0, 0);
              Day _lunes = new Day();
              _schedule.Day = new List<Day>() { new Day() { Name="Lunes2" }, new Day() { Name = "Marte2" }, new Day() { Name = "Miercoles2" } };
              _restaurant.Schedule = _schedule;



          }

          private void restaurantAssertions(bool edit = false)
          {
              Currency _currency = new Currency();
              _currency.Symbol = "C:/";
              _currency.Name = "Dolar";
              _restaurant.Currency = _currency;

              Coordinate _coordinate = new Coordinate();
              _coordinate.Latitude = 1;
              _coordinate.Longitude = 4;
              _restaurant.Coordinate = _coordinate;

              RestaurantCategory _restaurantCategory = new RestaurantCategory();
              _restaurantCategory.Name = "China";
              _restaurant.RestaurantCategory = _restaurantCategory;

               Zone _zone = new Zone();
               _zone.Name = "Caracas";
               _restaurant.Zone = _zone;

              _restaurant.MenuCategories = new List<MenuCategory>() {
                  new MenuCategory() { Name = "Italiana", Status = _facDAO.GetActiveSimpleStatus()}
              };
              Schedule _schedule = new Schedule();
              _schedule.OpeningTime = new TimeSpan(7, 0, 0);
              _schedule.ClosingTime = new TimeSpan(15, 0, 0);
              _restaurant.Schedule = _schedule;

              /*Assert.IsNotNull(_restaurant);
              Assert.AreEqual(_restaurant.Name, "Tierra Mar");
              Assert.AreEqual(_restaurant.Logo, "C:/");
              Assert.AreEqual(_restaurant.Nationality, 'V');
              Assert.AreEqual(_restaurant.Ssn, "123456");
              Assert.AreEqual(_restaurant.Address, "Av. El ejercito con puente de San Juan");
              Assert.AreEqual(_restaurant.Status, _facDAO.GetActiveSimpleStatus());
              Assert.AreEqual(_restaurant.Currency, _currency);
              Assert.AreEqual(_restaurant.Coordinate, _coordinate);
              Assert.AreEqual(_restaurant.RestaurantCategory, _restaurantCategory);
              //Assert.AreEqual(_restaurant.MenuCategories[0], _menuCategories);
              Assert.AreEqual(_restaurant.Schedule, _schedule);
               Assert.AreEqual(_restaurant.Zone, _zone);
          }

          [Test]
          public void RestaurantSave()
          {
              generateRestaurant();
              getRestaurantDao();
              _restaurantDAO.Save(_restaurant);
              Assert.AreNotEqual(_restaurant.Id, 0);
              _restaurantId = _restaurant.Id;
              generateRestaurant(true);
              _restaurantDAO.Save(_restaurant);
              //_restaurantDAO.ResetSession();
              _restaurant = null;
          }

          private void getRestaurantDao()
          {
              getDao();
              if (_restaurantDAO == null)
                  _restaurantDAO = _facDAO.GetRestaurantDAO();
          }

          private void getDao()
          {
              if (_facDAO == null)
                  _facDAO = FactoryDAO.Intance;
          }

          [TestFixtureTearDown]
          public void EndTests()
          {

          }*/

    }
}
