using System.Collections.Generic;
using NUnit.Framework;
using SendEmailService.Configuration;
using SendEmailService.Services;

namespace SendEmailService.Tests
{
    [TestFixture]
    public class EmailSendingTests
    {
        [Test, Explicit]
        public void SendsEmail()
        {
            var service = new MailManService(new List<string>{"a@b.com", "c@d.com"}, "noreply@me.com", "Test", "**Body** as _markdown_" )
                {
                    SenderConfiguration = new LocalMailer().GetSettings()
                };

            service.Send();

            //go find it in the pickup directory
        }
    }
}