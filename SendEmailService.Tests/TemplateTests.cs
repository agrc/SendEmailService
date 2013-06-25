using System.Collections.Generic;
using NUnit.Framework;
using SendEmailService.Commands;
using SendEmailService.Commands.Infrastructure;
using SendEmailService.Models.Database;

namespace SendEmailService.Tests
{
    [TestFixture]
    public class TemplateTests
    {
        [Test]
        public void CanReplaceVariableThatExist()
        {
            var template = new Templates(1, "subject", "{{int}}: {{replace}}, {{me}}, used the stuff to {{stuff}}.");

            dynamic variables = new Dictionary<string, object>
                {
                    {"replace", "Steve"},
                    {"me", "mapster po"},
                    {"stuff", "solve the problem"},
                    {"int", 1}
                };

            var command = new RenderTemplateCommand(template, variables);

            var content = CommandExecutor.ExecuteCommand(command);

            Assert.That(content, Is.EqualTo("1: Steve, mapster po, used the stuff to solve the problem."));
        }

        [Test]
        public void StripsVariableWhenDoesntExist()
        {
            var template = new Templates(1, "subject", "{{int}}: {{replace}}, {{me}}, used the stuff to {{stuff}}.{{whut}}{{whereAmI}}");

            dynamic variables = new Dictionary<string, object>
                {
                    {"replace", "Steve"},
                    {"me", "mapster po"},
                    {"stuff", "solve the problem"},
                    {"int", 1}
                };

            var command = new RenderTemplateCommand(template, variables);

            var content = CommandExecutor.ExecuteCommand(command);

            Assert.That(content, Is.EqualTo("1: Steve, mapster po, used the stuff to solve the problem."));
        }

        [Test]
        public void ExtraVariablesDontCauseProblems()
        {
            var template = new Templates(1, "subject", "{{int}}: {{replace}}, {{me}}, used the stuff to {{stuff}}.");

            dynamic variables = new Dictionary<string, object>
                {
                    {"replace", "Steve"},
                    {"me", "mapster po"},
                    {"stuff", "solve the problem"},
                    {"int", 1},
                    {"lost", "where am i?"}
                };

            var command = new RenderTemplateCommand(template, variables);

            var content = CommandExecutor.ExecuteCommand(command);

            Assert.That(content, Is.EqualTo("1: Steve, mapster po, used the stuff to solve the problem."));
        }

        [Test]
        public void ParkCityTemplateLooksGood()
        {
            var template = new Templates(1, "Request for new Soil Certificate of Compliance", "There was a request sent from {{url}} for a **copy** of a Soil Certificate of Compliance.\r\n\r\nName: {{name}}  \r\nAddress: {{address}}  \r\nPhone: {{phone}}  \r\nEmail: {{email}}");

            dynamic variables = new Dictionary<string, object>
                {
                    {"url", "http://utah.gov"},
                    {"name", "some poor soul"},
                    {"address", "123 main street"},
                    {"phone", 18003968415},
                    {"email", "test@email.com"}
                };

            var command = new RenderTemplateCommand(template, variables);

            var content = CommandExecutor.ExecuteCommand(command);

            Assert.That(content, Is.EqualTo("There was a request sent from http://utah.gov for a **copy** of a Soil Certificate of Compliance.\r\n\r\nName: some poor soul  \r\nAddress: 123 main street  \r\nPhone: 18003968415  \r\nEmail: test@email.com"));
        }
    }
}