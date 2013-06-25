using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;

namespace SendEmailService
{
    public class App : HttpApplication
    {
        public static IKernel Kernel { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var assemblyToScan = Assembly.GetExecutingAssembly();
            TemplateConfig.SeedDatabaseTemplates(assemblyToScan);
            EmailConfig.SeedDatabaseEmailRecipients(assemblyToScan);
        }
    }
}