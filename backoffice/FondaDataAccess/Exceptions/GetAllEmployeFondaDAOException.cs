﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.DataAccess.Exceptions
{
    public class GetAllEmployeFondaDAOException : FondaDAOException
    {
        public GetAllEmployeFondaDAOException () : base() {	}

		public GetAllEmployeFondaDAOException (string message) : base(message) {	}

        public GetAllEmployeFondaDAOException(string message, Exception InnerException)
			: base(message, InnerException) {	}
    }
}
