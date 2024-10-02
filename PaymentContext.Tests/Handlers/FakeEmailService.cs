using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Handlers;

public class FakeEmailService : IEmailService
{
    public void Send(string to, string email, string subject, string body)
    {
        
    }
}