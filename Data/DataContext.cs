
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
             var connectionString = _configuration.GetConnectionString("DefaultConnection");
             options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)); 

        }
        public DbSet<AppUser> Users {get;set;}

    }
}