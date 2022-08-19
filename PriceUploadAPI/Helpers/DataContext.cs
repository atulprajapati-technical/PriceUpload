using Microsoft.EntityFrameworkCore;
using PriceUploadAPI.Entities;

namespace PriceUploadAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("PriceUploadDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PriceUpload> PriceUpload { get; set; }
    }
}
