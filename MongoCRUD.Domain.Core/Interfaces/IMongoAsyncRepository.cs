using MongoCRUD.Domain.Core.Entities;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace MongoCRUD.Domain.Core.Interfaces;

public interface IMongoAsyncRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> expression);
    Task<T> GetOneWhere(Expression<Func<T, bool>> expression);

    Task Create(T entity);
    Task Update(T entity);
    Task Delete(ObjectId id);
}