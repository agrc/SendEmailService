using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;

namespace SendEmailService
{
    public class App : System.Web.HttpApplication
    {
        public static IKernel Kernel { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            TemplateConfig.SeedDatabaseTemplates(Assembly.GetCallingAssembly());
        }
    }
}