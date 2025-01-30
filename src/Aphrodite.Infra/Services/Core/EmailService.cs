using Aphrodite.Domain.CoreContext.Services;

namespace Aphrodite.Infra.Services.Core;

public class EmailService : IEmailService
{
    public void Send(string to, string from, string subject, string body)
    {
        throw new NotImplementedException();
    }
}