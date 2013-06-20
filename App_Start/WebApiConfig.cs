using System.Web.Http;

namespace SendEmailService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
