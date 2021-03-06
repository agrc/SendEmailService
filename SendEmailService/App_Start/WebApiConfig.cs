﻿using System.Web.Http;
using Newtonsoft.Json;
using SendEmailService.Handlers;
using SendEmailService.Ninject;

namespace SendEmailService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            config.MessageHandlers.Add(new CorsHandler());

            config.MapHttpAttributeRoutes();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(App.Kernel);

#if DEBUG
            config.EnableSystemDiagnosticsTracing();
#endif
        }
    }
}