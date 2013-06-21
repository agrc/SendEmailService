using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;
using Raven.Client;
using SendEmailService.Attributes;
using SendEmailService.Extensions;
using SendEmailService.Models.Database;

namespace SendEmailService
{
    public class TemplateConfig
    {
        public static void SeedDatabaseTemplates(Assembly assemblyToScan)
        {
            var templates = FindAllTemplates(assemblyToScan);
            var documentStore = App.Kernel.Get<IDocumentStore>();

            using (var session = documentStore.OpenSession())
            {
                foreach (var instance in templates)
                {
                    if (!typeof(IEmailTemplate).IsAssignableFrom(instance))
                        continue;

                    var t = Activator.CreateInstance(instance) as IEmailTemplate;

                    if (session.Query<Templates>().Any(x => x.Name == t.Name))
                        continue;

                    var template = new Templates(t.Subject, t.Body, t.VariableNames, t.Name);

                    session.Store(template);
                }

                session.SaveChanges();
            }
        }

        private static IEnumerable<Type> FindAllTemplates(Assembly assemblyToScan)
        {
            return assemblyToScan.FindTypesWithAttribute(typeof (TemplateAttribute));
        }
    }
}