using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    
    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("06304497679", EDocumentType.CPF);
        _email = new Email("coacci@gmail.com");
        _subscription = new Subscription(null);
        _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "Brasil", "13400000");
        _student = new Student(_name, _document, _email);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment(
            DateTime.Now, 
            DateTime.Now.AddDays(5), 
            10, 
            10, 
            _document, 
            _address, 
            "WAYNE CORP", 
            _email, 
            "123456789");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);
        
        _student.AddSubscription(subscription);
        Assert.IsFalse(_student.IsValid);
    }    
    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment(
            DateTime.Now, 
            DateTime.Now.AddDays(5), 
            10, 
            10, 
            _document, 
            _address, 
            "WAYNE CORP", 
            _email, 
            "123456789");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        Assert.IsTrue(_student.IsValid);
    }
}