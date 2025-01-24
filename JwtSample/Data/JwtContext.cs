using System.Reflection;
using System.Runtime.CompilerServices;
using JwtSample.Entity;
using Microsoft.EntityFrameworkCore;

namespace JwtSample.Data
{
    public class JwtContext(DbContextOptions<JwtContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public static class ContextRegistory
    {
        public static IServiceCollection AddDbContextSettings(this IServiceCollection services)
        {
            services.AddDbContext<JwtContext>((o) =>
            {
                o.UseInMemoryDatabase("JwtDb");
            });
            return services;
        }
    }
}
