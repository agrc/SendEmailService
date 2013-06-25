using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;
using Raven.Client;
using SendEmailService.Attributes;
using SendEmailService.Extensions;
using SendEmailService.Indexes;
using SendEmailService.Models.Database;
using SendEmailService.Models.Recipients;

namespace SendEmailService
{
    public class EmailConfig
    {
        public static void SeedDatabaseEmailRecipients(Assembly assemblyToScan)
        {
            var templates = FindAllRecipients(assemblyToScan);
            var documentStore = App.Kernel.Get<IDocumentStore>();

            using (var session = documentStore.OpenSession())
            {
                foreach (var instance in templates)
                {
                    if (!typeof (IEmailable).IsAssignableFrom(instance))
                        continue;

                    var recipient = Activator.CreateInstance(instance) as IEmailable;

                    if (session.Query<Emails, EmailByIdIndex>().Any(x => x.EmailId == recipient.EmailId))
                        continue;

                    var email = new Emails(recipient.Email, recipient.EmailId);

                    session.Store(email);
                }

                session.SaveChanges();
            }
        }

        private static IEnumerable<Type> FindAllRecipients(Assembly assemblyToScan)
        {
            return assemblyToScan.FindTypesWithAttribute(typeof (RecipientAttribute));
        }
    }
}