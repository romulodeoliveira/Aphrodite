namespace Aphrodite.Domain.CoreContext.Services;

public interface IEmailService
{
    void Send(string to, string from, string subject, string body);
}