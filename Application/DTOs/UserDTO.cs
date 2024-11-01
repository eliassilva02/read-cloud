using Domain.Enums;

namespace Application.DTOs;

public class UserDTO(string name, string email, string password, string userName, string phone, string cpf, AddressDTO address, DateTime dateBirth, int levelUser)
{
    public string Name { get; set; } = name;
    public string UserName { get; set; } = userName;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public string Cpf { get; set; } = cpf;
    public DateTime DateBirth { get; set; } = dateBirth;
    public string Phone { get; set; } = phone;
    public AddressDTO Address { get; set; } = address;
    public ELevelUser LevelUser { get; set; } = (ELevelUser)levelUser;
}
