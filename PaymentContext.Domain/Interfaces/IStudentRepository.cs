using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Interfaces;

public interface IStudentRepository
{
    bool DocumentExists(string document);
    bool EmailExists(string email);
    void CreateSubscription(Student student);
}