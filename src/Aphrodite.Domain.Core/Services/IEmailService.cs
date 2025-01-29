namespace Aphrodite.Domain.Core.Services;

public interface IEmailService
{
    void Send(string to, string from, string subject, string body);
}