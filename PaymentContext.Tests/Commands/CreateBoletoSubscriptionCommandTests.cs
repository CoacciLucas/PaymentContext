using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreateBoletoSubscriptionCommand
        {
            FirstName = "",
            LastName = ""
        };
        command.Validate();
        
        Assert.IsFalse(command.IsValid);
    }
}