using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        #region Notifications

        AddNotifications(new Contract<Address>()
                .Requires()
                .IsNotNullOrEmpty(Street, "Address.Street", "A rua deve ser preenchida.")
                .IsLowerOrEqualsThan(Street, 100, "Address.Street", "A rua deve conter até 100 caracteres.")
                .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres.")
                .IsNotNullOrEmpty(Number, "Address.Number", "O número deve ser preenchido.")
                .IsLowerOrEqualsThan(Number, 10, "Address.Number", "O número deve conter até 10 caracteres.")
                .IsNotNullOrEmpty(Neighborhood, "Address.Neighborhood", "O bairro deve ser preenchido.")
                .IsLowerOrEqualsThan(Neighborhood, 50, "Address.Neighborhood",
                    "O bairro deve conter até 50 caracteres.")
                .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood",
                    "O bairro deve conter pelo menos 3 caracteres.")
                .IsNotNullOrEmpty(City, "Address.City", "A cidade deve ser preenchida.")
                .IsLowerOrEqualsThan(City, 50, "Address.City", "A cidade deve conter até 50 caracteres.")
                .IsGreaterOrEqualsThan(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres.")
                .IsNotNullOrEmpty(State, "Address.State", "O estado deve ser preenchido.")
                .IsLowerOrEqualsThan(State, 20, "Address.State", "O estado deve conter até 20 caracteres.")
                .IsGreaterOrEqualsThan(State, 2, "Address.State", "O estado deve conter pelo menos 2 caracteres.")
                .IsNotNullOrEmpty(Country, "Address.Country", "O país deve ser preenchido.")
                .IsLowerOrEqualsThan(Country, 50, "Address.Country", "O país deve conter até 50 caracteres.")
                .IsGreaterOrEqualsThan(Country, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres.")
                .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "O CEP deve ser preenchido.")
                .IsLowerOrEqualsThan(ZipCode, 10, "Address.ZipCode", "O CEP deve conter até 10 caracteres.")

            #endregion
        );
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}