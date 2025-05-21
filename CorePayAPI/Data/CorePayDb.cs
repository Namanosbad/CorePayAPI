using CorePayAPI.Entities.CorePayDB;
using CorePayAPI.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Data
{
    public class CorePayDb : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public CorePayDb(DbContextOptions<CorePayDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfigurations());
        }
    }
}
