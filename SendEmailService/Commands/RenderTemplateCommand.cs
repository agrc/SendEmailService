using Nustache.Core;
using SendEmailService.Commands.Infrastructure;
using SendEmailService.Models.Database;

namespace SendEmailService.Commands
{
    /// <summary>
    /// Renders values into templates
    /// </summary>
    public class RenderTemplateCommand : Command<string>
    {
        public RenderTemplateCommand(Templates template, dynamic variables)
        {
            Variables = variables;
            Template = template;
        }

        private dynamic Variables { get; set; }
        private Templates Template { get; set; }

        public override void Execute()
        {
            var content = Template.Body;

            if (string.IsNullOrEmpty(content))
            {
                Result = null;
                return;
            }

            content = Render.StringToString(Template.Body, Variables);
            content = Render.StringToString(content, Variables);

            Result = content;
        }

        public override string ToString()
        {
            return string.Format("{0}, Variables: {1}, Template: {2}", "RenderTemplateCommand", Variables, Template);
        }
    }
}