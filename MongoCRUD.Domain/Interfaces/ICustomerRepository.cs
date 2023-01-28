using MongoCRUD.Domain.Core.Interfaces;
using MongoCRUD.Domain.Entities;

namespace MongoCRUD.Domain.Interfaces;

public interface ICustomerRepository : IMongoAsyncRepository<Customer>
{ }