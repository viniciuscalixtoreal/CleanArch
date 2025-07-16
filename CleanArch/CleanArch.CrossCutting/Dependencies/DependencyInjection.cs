using CleanArch.Application.Members.Commands.Validations;
using CleanArch.Domain.Abstraction;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;

namespace CleanArch.CrossCutting.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var sqlServerConnection = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(sqlServerConnection);
            });

            // Registrar IDbConnection como uma instância única
            services.AddSingleton<IDbConnection>(provider =>
            {
                var connection = new SqlConnection(sqlServerConnection);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(myHandlers);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.Load("CleanArch.Application"));

            return services;
        }
    }
}
