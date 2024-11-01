using Domain.Entities;
using Domain.Validations.Interfaces;
using Flunt.Validations;

namespace Domain.Validations;

public class UserValidation(User user) : Contract<User>, IValidation
{
    private readonly User _user = user;

    public void Validation()
    {
        IsNullOrEmpty();

        if (Notifications.Count > 0)
            return;


    }

    public void IsNullOrEmpty()
    {
        Requires()
            .IsNotNullOrEmpty(_user.Name, "Name")
            .IsNotNullOrEmpty(_user.UserName, "UserName")
            .IsNotNullOrEmpty(_user.Email, "Email")
            .IsNotNullOrEmpty(_user.Cpf, "Cpf")
            .IsNotNullOrEmpty(_user.Password, "Password");
    }

    public void ValidateFormat()
    {
        Requires()
            .IsEmail(_user.Email, "Email");
    }
}
