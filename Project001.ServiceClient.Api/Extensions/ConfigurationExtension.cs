using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project001.ServiceClient.Domain.Handlers;
using Project001.ServiceClient.Domain.Handlers.Interfaces;
using Project001.ServiceClient.Domain.Repositories;
using Project001.ServiceClient.Infra.EntityFramework;
using Project001.ServiceClient.Infra.Repositories;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Project001.ServiceClient.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Service Client",
                    Description = "A api with .net core 3.1",
                    Contact = new OpenApiContact
                    {
                        Name = "Bruno Daguis",
                        Email = "bruno.daguis@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/bruno-daguis/"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        public static void ConfigureDependecyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionString"];

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Connection String não inicializada");

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClientHandler, ClientHandler>();
        }
        public static void ConfigureJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration["KeySecretAuth"];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
