using Microsoft.EntityFrameworkCore;
using CorePay.API.Application.Interfaces;
using CorePay.API.Shared.Configuration;
using CorePayAPI.Data;
using CorePayAPI.Repository;
using CorePayAPI.Repository.Interface;
using CorePayAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using CorePay.API.Application.Services;

namespace CorePay.API.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCorePayDB(configuration);
            services.AddApplicationServices(configuration);

            return services;
        }

        public static IServiceCollection AddCorePayDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DbConfig>(config => configuration.GetRequiredSection(nameof(DbConfig)).Bind(config));

            //options 
            services.AddDbContext<CorePayDb>((serviceProvider, options) =>
            {
                var config = serviceProvider.GetRequiredService<IOptions<DbConfig>>().Value;
                var connectionString = config.ConnectionString;
                options.UseSqlServer(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<ITransferRepository, TransferRepository>();
            return services;
        }
    }
}