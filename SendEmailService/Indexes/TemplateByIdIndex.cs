using System.Linq;
using Raven.Client.Indexes;
using SendEmailService.Models.Database;

namespace SendEmailService.Indexes
{
    /// <summary>
    /// Provides the ability to search Templates by TemplateId
    /// </summary>
    public class TemplateByIdIndex : AbstractIndexCreationTask<Templates>
    {
        public TemplateByIdIndex()
        {
            Map = xx => from x in xx
                        select new
                            {
                                x.TemplateId
                            };
        }
    }
}