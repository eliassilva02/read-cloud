namespace Application.DTOs;

public class AddressDTO(string cep, string street, int number, string city, string state, string country, string? complement, string? referencePoint)
{
    public string Cep { get; set; } = cep;
    public string Street { get; set; } = street;
    public int Number { get; set; } = number;
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public string Country { get; set; } = country;
    public string? Complement { get; set; } = complement;
    public string? ReferencePoint { get; set; } = referencePoint;
}