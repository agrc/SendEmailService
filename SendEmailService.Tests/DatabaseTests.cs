using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using SendEmailService.Indexes;
using SendEmailService.Models.Database;
using SendEmailService.Models.Parameters;

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

                IndexCreation.CreateIndexes(typeof (EmailByIdIndex).Assembly, _documentStore);

                //arrange
                using (var s = _documentStore.OpenSession())
                {
                    s.Store(new Emails("1", 1));

                    s.Store(new Emails("2", 2));

                    s.Store(new Emails("3", 3));

                    s.Store(new Emails("4", 4));

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
                    var fromAddress = session.Query<Emails, EmailByIdIndex>()
                                             .Customize(x => x.WaitForNonStaleResultsAsOfLastWrite())
                                             .Single(x => x.EmailId == email.FromId).Email;

                    Assert.That(fromAddress, Is.EqualTo("1"));
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
//                    var to = session.Advanced.LuceneQuery<Emails, EmailByIdIndex>()
//                                    .WaitForNonStaleResultsAsOfLastWrite()
//                                    .Where(string.Format("EmailId:({0})", string.Join(" OR ", email.ToIds)))
//                                    .Select(x => x.Email).ToList();

                    var to = session.Advanced.DocumentQuery<Emails, EmailByIdIndex>()
                        .WaitForNonStaleResultsAsOfLastWrite()
                        .Where(string.Format("EmailId:({0})", string.Join(" OR ", email.ToIds)))
                        .Select(x => x.Email).ToList();

                    Assert.That(to.Count(), Is.EqualTo(3));
                }
            }
        }
    }
}