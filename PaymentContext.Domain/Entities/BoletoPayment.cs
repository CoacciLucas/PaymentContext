using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    Address address,
    string payer,
    Email email,
    string barCode,
    string boletoNumber)
    : Payment(paidDate, expireDate, total, totalPaid, document, address, payer, email)
{
    public string BarCode { get; private set; } = barCode;
    public string BoletoNumber { get; private set; } = boletoNumber;
}