﻿using System;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;

namespace com.ds201625.fonda.DataAccess.HibernateDAO
{
    public class HibernatePersonDAO
        : HibernateGenericPersonDAO<Person>, IPersonDAO
    {
    
    }
}

