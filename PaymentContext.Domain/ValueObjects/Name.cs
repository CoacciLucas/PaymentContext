using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O nome deve ser preenchido.")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "O nome deve conter até 40 caracteres.")
            .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos de 3 caracteres.")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "O sobrenome deve ser preenchido.")
            .IsLowerOrEqualsThan(LastName, 40, "Name.LastName", "O sobrenome deve conter até 40 caracteres.")
            .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "O sobrenome deve conter pelo menos de 3 caracteres."));
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}