﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;
using System.Web.Script.Serialization;
using BackOfficeModel.OrderAccount;
using BackOffice.Seccion.Restaurant;
using BackOfficePresenter.OrderAccount;
using FondaResources.Login;

namespace BackOffice.Seccion.Caja
{
    public partial class OrdenesCerradas : System.Web.UI.Page, IClosedOrdersModel
    {
        #region Presenter

        private ClosedOrdersPresenter _presenter;

        #endregion

        #region Model

        public Label ErrorLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Web.UI.WebControls.Table ClosedOrdersTable
        {
            get { return _closedOrders; }

            set { _closedOrders = value; }
        }

        public Label SuccessLabelMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Constructor

        public OrdenesCerradas()
        {
            _presenter = new ClosedOrdersPresenter(this);
        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RestaurantID"] != null)
            {   //Llama al presentador para llenar la tabla de ordenes
                _presenter.GetClosedOrders(Session[RestaurantResource.SessionRestaurant].ToString());
            }
        }


    }
}