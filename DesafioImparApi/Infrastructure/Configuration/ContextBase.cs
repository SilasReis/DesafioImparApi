using Impar.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Photo> Photo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetConnectionString()
        {
            return "Server = tcp:processo - seletivo.database.windows.net,1433; Initial Catalog = sqldb - silasreis; Persist Security Info = False; User ID = silasreis; Password = 2kh7ZiLt65X4ZjwduiQN8HvY; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
        }
    }
}
