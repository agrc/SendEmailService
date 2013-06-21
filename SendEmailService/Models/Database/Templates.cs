namespace SendEmailService.Models.Database
{
    public class Templates : IEmailTemplate
    {
        public Templates(string subject, string body, string[] variableNames, string name)
        {
            Subject = subject;
            Body = body;
            VariableNames = variableNames;
            Name = name;
        }

        public int Id { get; set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string[] VariableNames { get; private set; }
        public string Name { get; private set; }
    }
}