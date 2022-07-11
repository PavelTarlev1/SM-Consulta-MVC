using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SM_Consulta_MVC.Models.Entity;

namespace Auth_Api.Data.DataAccess
{
    public class UserContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public UserContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<UserEntity> UserEntities { get; set; }

    }
}
