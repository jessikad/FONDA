﻿using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.Logic.FondaLogic.FondaCommandException.Login
{
    /// <summary>
    /// excepcion que es lanzada en caso de que falle una consulta de useraccount
    /// </summary>
    public class CommandExceptionSaveUserAccount : FondaLogicException
    {
        public CommandExceptionSaveUserAccount() : base() { }

        public CommandExceptionSaveUserAccount(string message) : base(message) { }

        public CommandExceptionSaveUserAccount(string message, Exception InnerException)
			: base(message, InnerException) { }
    }
}
