using Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EFCore.Extensions
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddSqlServerDbContext<TDbContext>(this IServiceCollection services,
            string connString, Action<DbContextOptionsBuilder> doMoreDbContextOptionsConfigure = null,
            Action<IServiceCollection> doMoreActions = null,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
                where TDbContext : DbContext, IDbFacadeResolver, IDomainEventContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                options.UseSqlServer(connString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name);
                    // Thêm bất kỳ cấu hình nâng cao nào cho SQL Server ở đây
                });

                doMoreDbContextOptionsConfigure?.Invoke(options);
            }, serviceLifetime);

            services.AddScoped<IDbFacadeResolver>(provider => provider.GetService<TDbContext>());
            services.AddScoped<IDomainEventContext>(provider => provider.GetService<TDbContext>());


            doMoreActions?.Invoke(services);

            return services;
        }
    }
}
