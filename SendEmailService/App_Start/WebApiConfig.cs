using System.Web.Http;
using SendEmailService.Ninject;

namespace SendEmailService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(App.Kernel);

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
