using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }

    public string BarCode { get; set; }
    public string BoletoNumber { get; set; }

    public string PaymentNumber { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string PayerEmail { get; set; }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O nome deve ser preenchido.")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "O nome deve conter até 40 caracteres.")
            .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos de 3 caracteres.")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "O sobrenome deve ser preenchido.")
            .IsLowerOrEqualsThan(LastName, 40, "Name.LastName", "O sobrenome deve conter até 40 caracteres.")
            .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "O sobrenome deve conter pelo menos de 3 caracteres."));
    }
}