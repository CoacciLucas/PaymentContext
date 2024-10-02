using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;
[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand
        {
            FirstName = "Bruce",
            LastName = "Wayne",
            Document = "06304497679",
            Email = "coacci2@gmail.com",
            BarCode = "123456789",
            BoletoNumber = "123456789",
            PaymentNumber = "123456",
            PaidDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddMonths(1),
            Total = 60,
            TotalPaid = 60,
            Payer = "WAYNE CORP",
            PayerDocumentType = EDocumentType.CPF,
            PayerEmail = "batman@gd.com",
            Street = "asdasd",
            Number = "asdasd",
            Neighborhood = "asdasd",
            City = "asdasd",
            State = "asdasd",
            Country = "asdasd",
            ZipCode = "31170190"
        };
        handler.Handle(command);
        
        Assert.AreEqual(false, handler.IsValid);
    }
}