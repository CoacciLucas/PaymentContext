using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Document document,
        Address address,
        string payer,
        Email email)
    {
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Document = document;
        Address = address;
        Payer = payer;
        Email = email;
        
        AddNotifications(new Contract<Payment>()
            .Requires()
            .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero.")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento."));
    }

    public string Number { get; private set; } = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public string Payer { get; private set; }
    public Email Email { get; private set; }
}