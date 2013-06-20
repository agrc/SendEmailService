﻿using System;
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
                foreach (var instance in from template in templates
                                         where typeof (IEmailTemplate).IsAssignableFrom(template)
                                         select Activator.CreateInstance(template) as IEmailTemplate)
                {
                    if (session.Query<IEmailTemplate>().Any(x => x.Id == instance.Id))
                        continue;

                    session.Store(instance);
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