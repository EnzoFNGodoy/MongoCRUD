using Flunt.Validations;
using MongoCRUD.Domain.Core.ValueObjects;
using MongoCRUD.Domain.Helpers;

namespace MongoCRUD.Domain.ValueObjects;

public sealed class Password : ValueObject
{
    public Password(string passwordTyped)
    {
        PasswordTyped = passwordTyped;

        AddNotifications(new Contract<Password>()
            .Requires()
            .IsTrue(PasswordTyped.IsEmpty(), "Password.PasswordTyped", "A senha não pode ser vazia")
            .IsLowerThan(6, PasswordTyped.Length, "Password.PasswordTyped", "A senha deve possuir mais de 6 caracteres")
            .IsGreaterThan(40, PasswordTyped.Length, "Password.PasswordTyped", "A senha deve possuir menos de 40 caracteres")
            .IsTrue(Validate(), "Password.PasswordTyped", "A senha precisa ter pelo menos uma letra maiúscula, uma letra minúscula, um número e um carácter especial")
            );
    }

    public string PasswordTyped { get; private set; }

    private bool Validate()
    {
        if (PasswordTyped.HasUpperCase() &&
           PasswordTyped.HasLowerCase() &&
           PasswordTyped.HasSpecialChar() &&
           PasswordTyped.HasNumber())
            return true;

        return false;
    }
}