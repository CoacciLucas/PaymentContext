using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Interfaces;

namespace PaymentContext.Domain.Repositories;

public class StudentRepository : IStudentRepository
{
    public bool DocumentExists(string document)
    {
        return false;
    }

    public bool EmailExists(string email)
    {
        return false;
    }

    public void CreateSubscription(Student student)
    {
        
    }
}