﻿using com.ds201625.fonda.BackEndLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBeckEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un userAccount en GetAccountEmailCommand
    /// </summary>
    public class GetAccountEmailCommandException : FondaBackendLogicException
    {
        public GetAccountEmailCommandException  () : base() {	}

		public GetAccountEmailCommandException (string message) : base(message) {	}

        public GetAccountEmailCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
