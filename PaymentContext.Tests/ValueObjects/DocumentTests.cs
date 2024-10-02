using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;
[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsFalse(doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("07319717000140", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    [TestMethod]
    [DataRow("12312312")]
    [DataRow("1212312")]
    [DataRow("851501221312710024")]
    [DataRow("0000000")]
    [DataRow("")]
    public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsFalse(doc.IsValid);
    }
    [TestMethod]
    [DataTestMethod]
    [DataRow("06304497679")]
    [DataRow("33339318000")]
    [DataRow("85150710024")]
    [DataRow("85150710024")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}