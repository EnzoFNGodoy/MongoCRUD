using MongoCRUD.Domain.Core.Entities;
using MongoCRUD.Domain.ValueObjects;

namespace MongoCRUD.Domain.Entities;

public sealed class Customer : Entity
{
    public Customer(Name name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;

        AddNotifications(Name, Email, Password);
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
}