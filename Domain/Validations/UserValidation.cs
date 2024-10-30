using Domain.Entities;
using Domain.Validations.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Validations;

public class UserValidation(User user) : Contract<User>, IValidation
{
    private readonly User _user = user;

    public void Validation()
    {
        IsNullOrEmpty();

        // Nao sentido continuar as validações se algum desses for vazio
        if (Notifications.Count > 0)
            return;


    }

    public void IsNullOrEmpty()
    {
        Requires()
            .IsNullOrEmpty(_user.Name, "Name")
            .IsNullOrEmpty(_user.UserName, "UserName")
            .IsNullOrEmpty(_user.Email, "Email")
            .IsNullOrEmpty(_user.Phone, "Phone")
            .IsNullOrEmpty(_user.Cpf, "Cpf")
            .IsNullOrEmpty(_user.Password, "Password")
            .IsNullOrEmpty(_user.DateOfBirth, "DateOfBirth");
    }

    public void ValidateFormat()
    {
        Requires()
            .IsEmail(_user.Email, "Email")
            .
    }
}
