using MongoCRUD.Domain.Core.Entities;
using MongoCRUD.Domain.Core.Interfaces;
using MongoCRUD.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MongoCRUD.Infra.Data.Repositories.Core;

public class MongoAsyncRepository<T> : IMongoAsyncRepository<T> where T : Entity
{
    private readonly MongoContext _context;
    protected readonly IMongoCollection<T> _collection;

    public MongoAsyncRepository(MongoContext context)
    {
        _context = context;
        _collection = _context!.Database.GetCollection<T>(_context.GetCollectionName(typeof(T)));
    }

    #region Queries
    public virtual async Task<IEnumerable<T>> GetAll()
       => await _collection.FindAsync(x => true).Result.ToListAsync();

    public virtual async Task<T> GetOneWhere(Expression<Func<T, bool>> expression)
        => await _collection.FindAsync(expression).Result.FirstOrDefaultAsync();

    public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> expression)
        => await _collection.FindAsync(expression).Result.ToListAsync();
    #endregion

    #region Commands
    public async Task Create(T entity)
        => await _collection.InsertOneAsync(entity);

    public async Task Delete(ObjectId id)
        => await _collection.FindOneAndDeleteAsync(x => x.Id == id);

    public async Task Update(T entity)
        => await _collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
    #endregion
}