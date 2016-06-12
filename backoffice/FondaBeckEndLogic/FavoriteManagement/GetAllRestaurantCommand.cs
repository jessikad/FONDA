﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.Logic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;


namespace FondaBeckEndLogic.ProfileManagement
{
    class GetAllRestaurantCommand : BaseCommand 
    {
        public GetAllRestaurantCommand() : base() { }

        protected override Parameter[] InitParameters()
        {
            // Requiere 0 Parametros
            Parameter[] paramters = new Parameter[0];
            return paramters;
        }

		protected override void Invoke()
		{
            IList<Restaurant> listRestaurant;
			try
			{
                // Obtiene el dao que se requiere
                IRestaurantDAO RestaurantDAO = FacDao.GetRestaurantDAO();
                // Ejecucion del Buscar.	
                listRestaurant = (IList<Restaurant>)RestaurantDAO.GetAll();
                foreach (var restaurant in listRestaurant)
                {
                    restaurant.RestaurantCategory = new RestaurantCategory
                    {
                        Name = restaurant.RestaurantCategory.Name,
                        Id = restaurant.RestaurantCategory.Id
                    };

                }
			}
			catch (SaveEntityFondaDAOException e)  ////CAMBIAR EXEPCIONES
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error al gualrdar los datos",e);
			}
			catch (Exception e)
			{
				// TODO: Crear Excepcion personalizada
				throw new Exception("Error Desconocido",e);
			}
            //FALTA LOGGER
			// Guardar el resultado.
            Result = listRestaurant;
		}
	}
}