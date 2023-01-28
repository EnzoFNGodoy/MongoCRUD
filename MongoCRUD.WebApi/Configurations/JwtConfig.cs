using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoCRUD.Application.Auth;
using System.Data;
using System.Text;

namespace MongoCRUD.WebApi.Configurations;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services)
    {
        var key = Encoding.ASCII.GetBytes(Settings.SECRET);

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

        services.AddAuthorization();
    }
}