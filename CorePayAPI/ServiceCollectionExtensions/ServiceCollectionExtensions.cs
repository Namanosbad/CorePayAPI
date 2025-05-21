using CorePayAPI.Repository.Interface;
using CorePayAPI.Repository;
using CorePayAPI.Services.Interface;
using CorePayAPI.Services;
using CorePayAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.ServiceCollectionExtensions
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
            var connectionString = configuration.GetConnectionString("databaseUrl");

            services.AddDbContext<CorePayDb>(
                options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging()
            );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<ITransferRepository, TransferRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();

            return services;
        }
    }
}