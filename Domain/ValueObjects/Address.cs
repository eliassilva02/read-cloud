namespace Domain.ValueObjects;

public class Address
{
    public Address(string cep, string street, int number, string city, string? referencePoint, string? complement, string country)
    {
        Cep = cep;
        Street = street;
        Number = number;
        City = city;
        ReferencePoint = referencePoint;
        Complement = complement;
        Country = country;
    }

    public string Cep { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string? ReferencePoint { get; set; }
    public string? Complement { get; set; }
    public string Country { get; set; }
}
