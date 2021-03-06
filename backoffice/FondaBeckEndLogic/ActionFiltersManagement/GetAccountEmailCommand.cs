﻿using com.ds201625.fonda.DataAccess.Exceptions;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEndLogic.Exceptions;
using com.ds201625.fonda.Logic.FondaLogic.Log;
using System;
using FondaBeckEndLogic;

namespace com.ds201625.fonda.BackEndLogic.ActionFiltersManagement
{
    /// <summary>
    /// Comando para la Buscar un UserAccount por su email
    /// </summary>
    public class GetAccountEmailCommand : BaseCommand
    {
        /// <summary>
        /// constructor GetAccountEmailCommand
        /// </summary>
        public GetAccountEmailCommand() : base() { }
        /// <summary>
        /// Metodo para inicializar los parametros
        /// </summary>
        /// <returns>Un arreglo con los parametros email y password/returns>
        protected override Parameter[] InitParameters()
        {
            // Requiere 1 Parametro
            Parameter[] paramters = new Parameter[1];

            // [0] El email
            paramters[0] = new Parameter(typeof(String), true);

            return paramters;
        }

        /// <summary>
        /// Metodo Invoke para la ejecucion del 
        /// buscar un UserAccount especifico
        /// </summary>
        protected override void Invoke()
        {
            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   ResourceMessages.BeginLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            // Obtencion de parametros
            String email = (String)GetParameter(0);

            // Obtiene el dao CommensalDAO
            ICommensalDAO commensalDAO = FacDao.GetCommensalDAO();

            UserAccount user; 
            try
            {
                //Buscar el usuario
                user = commensalDAO.FindByEmail(email);

                if (user != null)
                Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 ResourceMessages.Commensal + user.Email, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (FindByEmailUserAccountFondaDAOException e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAccountEmailCommandException(ResourceMessages.GetUserException, e);
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new GetAccountEmailCommandException(ResourceMessages.GetUserException, e);
            }


            //Se guardan los resultados
            Result = user;

            Logger.WriteSuccessLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceMessages.EndLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
    }
}
