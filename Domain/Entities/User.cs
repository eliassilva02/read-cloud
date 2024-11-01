using Domain.Enums;
using Domain.Validations;
using Domain.ValueObjects;
using Flunt.Notifications;

namespace Domain.Entities;

public class User : Notifiable<Notification>
{
    public User(string name, string userName, string email, string telefone, Address address, string cpf, string password, DateTime dateOfBirth, ELevelUser levelUser)
    {
        Name = name;
        UserName = userName;
        Email = email;
        Phone = telefone;
        Address = address;
        Cpf = cpf;
        Password = password;
        DateOfBirth = dateOfBirth;
        LevelUser = levelUser;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public Address Address { get; private set; }
    public string Cpf { get; private set; }
    public string Password { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public ELevelUser LevelUser { get; private set; }


    public void Validation()
    {
        var validator = new UserValidation(this);
        validator.Validation();

        AddNotifications(validator.Notifications);
    }
}
