﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.FactoryDAO;



namespace FondaBeckEndLogic.ProfileManagement
{
    /// <summary>
    /// Get Commensal Email Command
    /// </summary>
    class GetCommensalEmailCommand : BaseCommand
    {
        /// <summary>
        /// constructor obtener comensal
        /// </summary>
        public GetCommensalEmailCommand() : base() { }

        /// <summary>
        /// metodo que inicializa los parametros
        /// </summary>
        /// <returns>paramters</returns>
		protected override Parameter[] InitParameters ()
		{
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El UserAccount
            paramters[0] = new Parameter(typeof(UserAccount), true);

            return paramters;
		}

        /// <summary>
        /// metodo invoke que ejecuta el buscar comensal por email 
        /// </summary>
        protected override void Invoke()
        {
            UserAccount answer;
            // Obtencion de parametros
            UserAccount commensal = (UserAccount)GetParameter(0);

            // Obtiene el dao que se requiere
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();
            // Ejecucion del Buscar.		
            try
            {
                 answer = (UserAccount)commensalDAO.FindByEmail(commensal.Email);
            }
            catch (SaveEntityFondaDAOException e)  ////CAMBIAR EXEPCIONES
            {
                // TODO: Crear Excepcion personalizada
                throw new Exception("Error al gualrdar los datos", e);
            }
            catch (Exception e)
            {
                // TODO: Crear Excepcion personalizada
                throw new Exception("Error Desconocido", e);
            }
            //FALTA LOGGER
            // Guardar el resultado.
            Result = answer;
        }
    }
}