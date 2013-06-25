using Ninject.Activation;
using Ninject.Modules;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using SendEmailService.Indexes;

namespace SendEmailService.Ninject
{
    public class RavenModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentStore>()
                .ToMethod(Init)
                .InSingletonScope();
        }

        private static IDocumentStore Init(IContext context)
        {
            var documentStore = new DocumentStore
                {
                    ConnectionStringName = "RavenDb"
                }.Initialize();

            IndexCreation.CreateIndexes(typeof(EmailByIdIndex).Assembly, documentStore);

            return documentStore;
        }
    }
}