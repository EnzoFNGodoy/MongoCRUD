using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Domain.Core.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = ObjectId.GenerateNewId();
        CreatedAt = Id.CreationTime.ToLocalTime();
        UpdatedAt = DateTime.Now.ToLocalTime();
        IsActive = true;
    }

    [BsonElement("id")]
    public ObjectId Id { get; protected set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; protected set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; protected set; }

    [BsonElement("isActive")]
    public bool IsActive { get; protected set; }

    public void Activate()
    {
        if (IsValid)
            IsActive = true;
    }

    public void Deactivate()
    {
        if (IsValid)
            IsActive = false;
    }
}