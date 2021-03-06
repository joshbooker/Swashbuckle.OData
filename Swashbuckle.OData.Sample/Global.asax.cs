﻿using System.Web;
using System.Web.Http;

namespace SwashbuckleODataSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FormatterConfig.Register);
        }
    }
}