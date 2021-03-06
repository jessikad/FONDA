﻿using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using System;
using System.Collections.Generic;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandReleaseTableByRestaurant : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;

        private IList<object> _list;
        private IRestaurantDAO _restaurantDAO;
        public CommandReleaseTableByRestaurant(Object receiver) : base(receiver) { }

        public override void Execute()
        {
            try
            {
                _list = (IList<object>)Receiver;
                Restaurant _restaurant = new Restaurant();
                int _tableId =0;
                _restaurant = (Restaurant) _list[0];
                _tableId = (int)_list[1];
                _restaurantDAO = _facDAO.GetRestaurantDAO();
                _restaurantDAO.ReleaseTable(_restaurant, _tableId);


            }
            catch (ReleaseTableFondaDAOException ex)
            {
                CommandExceptionReleaseTableByRestaurant exception = new CommandExceptionReleaseTableByRestaurant(
                    OrderAccountResources.CommandExceptionReleaseTableByRestaurantCode,
                    OrderAccountResources.ClassNameReleaseTableByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionReleaseTableByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;

            }
            catch (Exception ex)
            {
                CommandExceptionReleaseTableByRestaurant exception = new CommandExceptionReleaseTableByRestaurant(
                    OrderAccountResources.CommandExceptionReleaseTableByRestaurantCode,
                    OrderAccountResources.ClassNameReleaseTableByRestaurant,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionReleaseTableByRestaurant,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;

            }

            Logger.WriteSuccessLog(OrderAccountResources.ClassNameReleaseTableByRestaurant
                , OrderAccountResources.SuccessMessageCommandReleaseTableByRestaurant
                , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                );
        }
    }
}
