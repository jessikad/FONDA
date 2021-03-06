﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace com.ds201625.fonda.View.BackOfficeModel.OrderAccount
{
    public interface IDetailOrderContract : IContract
    {
        Table DetailOrderTable { get; set; }

        string Session { get; set; }

        string SessionNumberAccount { get; set; }

        Label DateOrder { get; set; }
    }
}
