using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    Address address,
    string payer,
    Email email,
    string cardHolderName,
    string cardNumber,
    string lastTransactionNumber)
    : Payment(paidDate, expireDate, total, totalPaid, document, address, payer, email)
{
    public string CardHolderName { get; set; } = cardHolderName;
    public string CardNumber { get; set; } = cardNumber;
    public string LastTransactionNumber { get; set; } = lastTransactionNumber;
}