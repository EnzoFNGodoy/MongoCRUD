using Microsoft.Extensions.DependencyInjection;
using MongoCRUD.Application.Interfaces;
using MongoCRUD.Application.Services;
using MongoCRUD.Domain.Interfaces;
using MongoCRUD.Infra.Data.Context;
using MongoCRUD.Infra.Data.Repositories;

namespace MongoCRUD.Infra.CrossCutting.IoC;

public static class NativeInjector
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterApplicationServices();
        services.RegisterInfraServices();
    }

    private static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<MongoContext>();
        services.AddScoped<ICustomerServices, CustomerServices>();
    }

    private static void RegisterInfraServices(this IServiceCollection services)
    {
        services.AddScoped<MongoContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}