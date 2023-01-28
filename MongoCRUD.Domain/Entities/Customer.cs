﻿using MongoCRUD.Domain.Core.Attributes;
using MongoCRUD.Domain.Core.Entities;
using MongoCRUD.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Domain.Entities;

[BsonCollection("Customers")]
public sealed class Customer : Entity
{
    public Customer(Name name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;

        AddNotifications(Name, Email, Password);
    }

    [BsonElement("Name")]
    public Name Name { get; private set; }
    [BsonElement("Email")]
    public Email Email { get; private set; }
    [BsonElement("Password")]
    public Password Password { get; private set; }
}