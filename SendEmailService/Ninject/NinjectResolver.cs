using System.Web.Http.Dependencies;
using Ninject;

namespace SendEmailService.Ninject
{
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            App.Kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(App.Kernel.BeginBlock());
        }
    }
}