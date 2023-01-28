using MongoCRUD.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuring Swagger
builder.Services.AddSwaggerConfiguration();

// Configuring AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configuring Dependency Injection
builder.Services.AddDependencyInjectionConfiguration();

// Configuring MongoDB
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configuring Jwt
builder.Services.AddJwtConfiguration();

var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
});

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
