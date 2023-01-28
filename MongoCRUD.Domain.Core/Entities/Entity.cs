using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUD.Domain.Core.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = ObjectId.GenerateNewId();
        CreatedAt = Id.CreationTime;
        UpdatedAt = DateTime.Now.ToLocalTime();
    }

    [BsonElement("id")]
    public ObjectId Id { get; private set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; private set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; private set; }

    [BsonElement("isActive")]
    public bool IsActive { get; private set; }

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

    public virtual void Update(ObjectId id)
    {
        if (IsValid)
            UpdatedAt = DateTime.Now.ToLocalTime();
    }
}