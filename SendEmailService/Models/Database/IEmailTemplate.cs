namespace SendEmailService.Models.Database
{
    public interface IEmailTemplate
    {
        int Id { get; set; }
        string Subject { get; }
        string Body { get; }
        string[] VariableNames { get; }
    }
}