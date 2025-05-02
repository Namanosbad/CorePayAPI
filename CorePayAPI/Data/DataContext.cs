using CorePayAPI.Entities;
using CorePayAPI.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CorePayAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfigurations());
        }
    }
}
