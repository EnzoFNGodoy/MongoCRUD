using Microsoft.Extensions.DependencyInjection;
using MongoCRUD.Domain.Interfaces;
using MongoCRUD.Infra.Data.Context;
using MongoCRUD.Infra.Data.Repositoriesl;

namespace Gooders.Shared.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterApplicationServices();
        services.RegisterInfraServices();
    }

    private static void RegisterApplicationServices(this IServiceCollection services)
    {

    }

    private static void RegisterInfraServices(this IServiceCollection services)
    {
        services.AddScoped<MongoContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}