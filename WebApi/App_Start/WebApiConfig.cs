using Ninject.Web.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.App_Start;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static ObservableDirectRouteProvider GlobalObservableDirectRouteProvider = new ObservableDirectRouteProvider();
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Web API routes
            config.MapHttpAttributeRoutes(GlobalObservableDirectRouteProvider);
        }
    }
}
