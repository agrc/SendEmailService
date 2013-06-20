using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using SendEmailService.Indexes;
using SendEmailService.Models;

namespace SendEmailService.Tests
{
    public class DatabaseTests
    {
        [TestFixture]
        public class EmailQuery
        {
            [SetUp]
            public void CreateDocumentStore()
            {
                _documentStore = new EmbeddableDocumentStore
                    {
                        RunInMemory = true
                    }.Initialize();

                IndexCreation.CreateIndexes(typeof (IndexEmailById).Assembly, _documentStore);

                //arrange
                using (var s = _documentStore.OpenSession())
                {
                    s.Store(new Emails
                        {
                            Id = 1,
                            Email = "1"
                        });

                    s.Store(new Emails
                        {
                            Id = 2,
                            Email = "2"
                        });

                    s.Store(new Emails
                        {
                            Id = 3,
                            Email = "3"
                        });

                    s.Store(new Emails
                        {
                            Id = 4,
                            Email = "4"
                        });

                    s.SaveChanges();
                }
            }

            [TearDown]
            public void TearDown()
            {
                _documentStore.Dispose();
            }

            private IDocumentStore _documentStore;

            [Test]
            public void CanGetEmailFromId()
            {
                var email = new EmailInformation
                    {
                        FromId = 1
                    };

                using (var session = _documentStore.OpenSession())
                {
                    var from = session.Load<Emails>(email.FromId).Email;

                    Assert.That(from, Is.EqualTo("1"));
                }
            }

            [Test]
            public void CanGetEmailsFromMultipleIds()
            {
                var email = new EmailInformation
                    {
                        ToIds = new List<int> {1, 3, 4}
                    };

                using (var session = _documentStore.OpenSession())
                {
                    var to = new Collection<string>();

                    foreach(var id in email.ToIds)
                    {
                        to.Add(session.Load<Emails>(id).Email);
                    }

                    Assert.That(to.Count(), Is.EqualTo(3));
                }
            }
        }
    }
}