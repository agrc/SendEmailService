using MarkdownMailer;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using SendEmailService.Configuration;

namespace SendEmailService.Ninject
{
    public class EmailModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMailSender>().ToMethod(Init).InRequestScope();
        }

        private static IMailSender Init(IContext context)
        {
            MailSenderConfiguration settings;

#if DEBUG
            settings = new LocalMailer().GetSettings();
#else
            settings = new SmtpMailer().GetSettings();
#endif

            return new MailSender(settings);
        }
    }
}