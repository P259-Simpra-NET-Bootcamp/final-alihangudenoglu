using DataAccess.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extension
{
    public static class DbContextExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services,IConfiguration configuration)
        {
            var dbType = configuration.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                var dbConfig = configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<EfDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<EfDbContext>();
            services.AddScoped<EfDbContext>();
        }
    }
}
