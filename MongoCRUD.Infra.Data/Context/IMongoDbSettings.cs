namespace MongoCRUD.Infra.Data.Context;

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }
    string ConnectionString { get; set; }
}