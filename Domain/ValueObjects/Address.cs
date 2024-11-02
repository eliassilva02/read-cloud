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

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Cep { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string City { get; private set; }
    public string? ReferencePoint { get; private set; }
    public string? Complement { get; private set; }
    public string Country { get; private set; }
}
