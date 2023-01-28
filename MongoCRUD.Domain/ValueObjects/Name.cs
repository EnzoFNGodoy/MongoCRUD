using Flunt.Validations;
using MongoCRUD.Domain.Core.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Name.FirstName", "O primeiro nome não pode ser vazio")
            .IsNotNullOrWhiteSpace(FirstName, "Name.FirstName", "O primeiro nome não pode ser vazio")
            .IsGreaterOrEqualsThan(FirstName.Length, 3, "Name.FirstName", "O primeiro nome não pode ter menos de 3 caracteres.")
            .IsLowerOrEqualsThan(FirstName.Length, 100, "Name.FirstName", "O primeiro nome não pode ter mais de 100 caracteres.")
            .IsNotNullOrEmpty(LastName, "Name.LastName", "O último nome não pode ser vazio")
            .IsNotNullOrWhiteSpace(LastName, "Name.LastName", "O último nome não pode ser vazio")
            .IsGreaterOrEqualsThan(LastName.Length, 3, "Name.LastName", "O último nome não pode ter menos de 3 caracteres")
            .IsLowerOrEqualsThan(LastName.Length, 100, "Name.LastName", "O último nome não pode ter mais de 100 caracteres")
            );
    }

    [BsonElement("FirstName")]
    public string FirstName { get; private set; }

    [BsonElement("LastName")]
    public string LastName { get; private set; }

    public override string ToString() => $"{FirstName} {LastName}";
}