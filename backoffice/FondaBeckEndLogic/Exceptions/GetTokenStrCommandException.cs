﻿using System;

namespace com.ds201625.fonda.BackEndLogic.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan al buscar
    /// un Token de un Commensal por Str en GetTokenStrCommand
    /// </summary>
    public class GetTokenStrCommandException : FondaBackendLogicException
    {
        public GetTokenStrCommandException  () : base() {	}

		public GetTokenStrCommandException  (string message) : base(message) {	}

        public GetTokenStrCommandException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
