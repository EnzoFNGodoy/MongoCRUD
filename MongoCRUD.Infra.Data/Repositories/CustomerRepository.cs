using Gooders.Shared.Infra.Data.Repositories.Core;
using MongoCRUD.Domain.Entities;
using MongoCRUD.Domain.Interfaces;
using MongoCRUD.Infra.Data.Context;

namespace MongoCRUD.Infra.Data.Repositoriesl;

public sealed class CustomerRepository : MongoAsyncRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(MongoContext context) : base(context)
    { }
}