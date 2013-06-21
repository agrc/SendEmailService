namespace SendEmailService.Models.Recipients
{
    public interface IEmailable
    {
        string Email { get; }
        string Id { get; }
    }
}