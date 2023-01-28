using MongoCRUD.Domain.Core.Attributes;
using MongoDB.Driver;

namespace MongoCRUD.Infra.Data.Context;

public sealed class MongoContext
{
    private readonly IMongoDbSettings _mongoDbSettings;

    public MongoContext(IMongoDbSettings mongoDbSettings)
    {
        _mongoDbSettings = mongoDbSettings;

        try
        {
            Database = new MongoClient(_mongoDbSettings.ConnectionString)
                .GetDatabase(_mongoDbSettings.DatabaseName);
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível se conectar com o servidor.", ex);
        }
    }

    public IMongoDatabase Database { get; } = null!;

    public string GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault()!)?.CollectionName!;
    }
}