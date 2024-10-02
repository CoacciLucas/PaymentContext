using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    Address address,
    string payer,
    Email email,
    string transactionCode)
    : Payment(paidDate, expireDate, total, totalPaid, document, address, payer, email)
{
    public string TransactionCode { get; set; } = transactionCode;
}