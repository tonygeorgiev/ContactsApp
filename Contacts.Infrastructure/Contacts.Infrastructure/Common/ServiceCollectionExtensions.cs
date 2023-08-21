using Contacts.Application.Repositories;
using Contacts.Infrastructure.Persistence;
using Contacts.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infrastructure.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSettings = configuration.GetSection(nameof(DatabaseConnectionOptions)).Get<DatabaseConnectionOptions>();

            if (dbSettings is not null)
            {
                services.AddSingleton(dbSettings);
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(dbSettings?.ConnectionString));

                services.AddTransient<IContactRepository, ContactRepository>();
                services.AddTransient<IUnitOfWork, UnitOfWork>();
            }

            return services;
        }
    }
}
