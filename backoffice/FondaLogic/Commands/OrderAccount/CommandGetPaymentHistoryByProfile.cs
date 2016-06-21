﻿using com.ds201625.fonda.Domain;
using FondaLogic.Factory;
using FondaLogic.FondaCommandException.OrderAccount;
using FondaLogic.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.Commands.OrderAccount
{
    public class CommandGetPaymentHistoryByProfile : Command
    {
        public CommandGetPaymentHistoryByProfile(Object receiver) : base(receiver) { }
        

        public override void Execute()
        {
            List<Object> parameters = new List<object>();
            List<Invoice> paymentHistory;
            Command validate, command;

            try
            {
                parameters = (List<Object>)Receiver;
                int profileId = (int) parameters[0];

                validate = CommandFactory.GetCommandValidateProfileByCommensal(parameters);
                command = CommandFactory.GetCommandGetInvoicesByProfile(profileId);
                validate.Execute();

                if ((bool)validate.Receiver)
                    command.Execute();
                else
                    throw new NullReferenceException();

                Receiver = command.Receiver;


            }
            catch (NullReferenceException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch(InvalidCastException ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch(CommandExceptionValidateProfileByCommensal ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch(CommandExceptionGetInvoicesByProfile ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
            catch(Exception ex)
            {
                //TODO: Arrojar Excepcion personalizada
                CommandExceptionGetPaymentHistoryByProfile exception = new CommandExceptionGetPaymentHistoryByProfile(
                    FondaResources.General.Errors.NullExceptionReferenceCode,
                    FondaResources.OrderAccount.Errors.ClassNameFindInvoicesByAccount,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    FondaResources.General.Errors.NullExceptionReferenceMessage,
                    ex);

                Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);

                paymentHistory = new List<Invoice>();
                Receiver = paymentHistory;
            }
        }

    }
}