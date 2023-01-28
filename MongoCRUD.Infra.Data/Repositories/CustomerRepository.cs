using MongoCRUD.Domain.Entities;
using MongoCRUD.Domain.Interfaces;
using MongoCRUD.Infra.Data.Context;
using MongoCRUD.Infra.Data.Repositories.Core;

namespace MongoCRUD.Infra.Data.Repositories;

public sealed class CustomerRepository : MongoAsyncRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(MongoContext context) : base(context)
    { }
}