using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Interfaces;

namespace PaymentContext.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    public bool DocumentExists(string document)
    {
        return document == "06304497679";
    }

    public bool EmailExists(string email)
    {
        return email == "coacci@gmail.com";
    }

    public void CreateSubscription(Student student)
    {
    }
}