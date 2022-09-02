using Application.Common.Interface.Authentication;
using Application.Common.Interface.Presistence;
using Application.Common.Interface.Services;
using Infrastructure.Authentication;
using Infrastructure.Presistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, ConfigurationManager configurationManger, string AppDbContextConnection)
        {



            services.AddDbContext<AppDbContext>(
                option =>
                option.UseSqlServer(AppDbContextConnection)
                );


            services.Configure<JwtSettings>(configurationManger.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerators, JwtTokenGenerator>();

            // JWT Bearer Authentication
            var jwtSetting = new JwtSettings();
            configurationManger.Bind(JwtSettings.SectionName, jwtSetting);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidIssuer = jwtSetting.Issueser,
                                ValidAudience = jwtSetting.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret))
                            }
            ); // JWT Bearer Authentication




            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}