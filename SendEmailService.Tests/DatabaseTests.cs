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
                        Email = "4s"
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
        }
    }
}