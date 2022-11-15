using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Infrastructure.Data.EntityFrameworkSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureMySqlServerDBContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RepositoryContextSQL>(
                    options => options.UseSqlServer(configuration.GetConnectionString("SqlServerDBContext"), npgsqlOptions => {
                        npgsqlOptions.CommandTimeout(60);
                    }),
                    ServiceLifetime.Transient
                );
        }
    }
}
