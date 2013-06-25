using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using SendEmailService.Models.Database;

namespace SendEmailService.Indexes
{
    /// <summary>
    /// Provides ability to search by EmailId
    /// </summary>
    public class EmailByIdIndex : AbstractIndexCreationTask<Emails>
    {
        public EmailByIdIndex()
        {
            Map = xx => from x in xx
                        select new
                            {
                                x.EmailId
                            };

            Index(x => x.EmailId, FieldIndexing.Analyzed);
        }
    }
}