﻿using System.Web;
using System.Web.Mvc;

namespace S00127670_CA1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}