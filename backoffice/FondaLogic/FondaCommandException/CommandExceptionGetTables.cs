﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaLogic.FondaCommandException
{
    public class CommandExceptionGetTables : CommandException
    {
        #region Constructors

        public CommandExceptionGetTables(string message, Exception ex) : base(message, ex)
        {
        }

        public CommandExceptionGetTables(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
