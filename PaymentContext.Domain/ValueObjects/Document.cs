using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract<Document>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Documento inválido."));
    }
    public string Number { get; private set; }
    public EDocumentType Type { get; set; }
    
    private bool Validate()
    {
        string document = new string(Number.Where(char.IsDigit).ToArray());

        if (Type == EDocumentType.CPF && Number.Length == 11)
            return ValidateCPF(document);
        
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return ValidateCNPJ(document);

        return false;
    }

    private bool ValidateCPF(string cpf)
    {
        if (cpf.Distinct().Count() == 1)
            return false;

        int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

        string tempCpf = cpf.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        tempCpf += digit;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder.ToString();
        return cpf.EndsWith(digit);
    }

    private bool ValidateCNPJ(string cnpj)
    {
        if (cnpj.Distinct().Count() == 1)
            return false;

        int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        tempCnpj += digit;
        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder.ToString();
        return cnpj.EndsWith(digit);
    }
}