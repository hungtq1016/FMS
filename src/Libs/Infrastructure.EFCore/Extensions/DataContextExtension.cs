using Infrastructure.EFCore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.EFCore.Extensions
{
    public static class DataContextExtension
    {
        public static IServiceCollection AddSqlServerDbContext<TDbContext>(this IServiceCollection services,
            string connString)
                where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(options =>
            {
                options.UseSqlServer(connString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(TDbContext).Assembly.GetName().Name);
                });
            });
            services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));
            services.AddSingleton<IUriService, UriService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
