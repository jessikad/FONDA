﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.ds201625.fonda.View.BackOfficePresenter.FondaMVPException.OrderAccount
{
    class MVPExceptionQuery : MVPException
    {
        #region Constructors

        public MVPExceptionQuery(string message, Exception ex) : base(message, ex)
        {
        }
        public MVPExceptionQuery(string message) : base(message)
        {
        }
        public MVPExceptionQuery(string id, string classname, string method, string message, Exception ex) 
            : base(id, classname, method, message, ex)
        {
        }

        #endregion
    }
}
