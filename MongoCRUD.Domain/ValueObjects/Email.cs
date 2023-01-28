using Flunt.Validations;
using MongoCRUD.Domain.Core.ValueObjects;

namespace MongoCRUD.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Email.Address", "Email inválido")
            );
    }

    public string Address { get; private set; }

    public override string ToString() => $"{Address}";
}