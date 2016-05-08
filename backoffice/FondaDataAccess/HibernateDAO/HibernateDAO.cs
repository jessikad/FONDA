﻿using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
	public class HibernateFactoryDAO : IFactoryDAO
	{
		public HibernateFactoryDAO () { }

		public ICommensalDAO GetCommensalDAO ()
		{
			return new HibernateCommensalDAO ();
		}

		public IProfileDAO GetProfileDAO ()
		{
			return new HibernateProfileDAO ();
		}

		public IUserAccountDAO GetUserAccountDAO ()
		{
			return new HibernateUserAccountDAO ();
		}

		public IPersonDAO GetPersonDao ()
		{
			return new HibernatePersonDAO ();
		}

		public ICompanyDAO GetCompanyDAO()
		{
			return new HibernateCompanyDAO ();
		}

		public IStatusDAO GetStatusDAO()
		{
			return new HibernateStatusDAO();
		}

        public IDishOrderDAO GetDishOrderDAO()
        {
            return null;
        }

        public IOrderAccountDao GetOrderAccountDAO()
        {
            return null;
        }

        public IDishDAO GetDishDAO()
        {
            return new HibernateDishDAO();
        }

        public IMenuCategoryDAO GetMenuCategoryDAO()
        {
            return new HibernateMenuCategoryDAO();
        }

        public ICoordinateDAO GetCoordinateDAO()
        {
            return new HibernateCoordinateDAO();
        }

        public ICurrencyDAO GetCurrencyDAO()
        {
            return new HibernateCurrencyDAO();
        }

        public IDayDAO GetDayDAO()
        {
            return new HibernateDayDAO();
        }

        public IRestaurantCategoryDAO GetRestaurantCategoryDAO()
        {
            return new HibernateRestaurantCategoryDAO();
        }

        public IRestaurantDAO GetRestaurantDAO()
        {
            return new HibernateRestaurantDAO();
        }

        public IScheduleDAO GetScheduleDAO()
        {
            return new HibernateScheduleDAO();
        }

        public ITableDAO GetTableDAO()
        {
            return new HibernateTableDAO();
        }
    }
}

