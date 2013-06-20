using System.Linq;
using Raven.Client.Indexes;
using SendEmailService.Models;

namespace SendEmailService.Indexes
{
    public class IndexEmailById: AbstractIndexCreationTask<Emails>
    {
        public IndexEmailById()
        {
            Map = xx => from x in xx
                        select new
                        {
                            x.Id
                        };
        }
    }
}