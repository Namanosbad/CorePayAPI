using CorePayAPI.Entities.CorePayDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CorePayAPI.EntitiesConfigurations
{
    public class UserEntityConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        { 
        builder.ToTable("User");
                    builder.HasKey(e => e.Id);
                    builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                                .IsRequired()
                                .HasMaxLength(100);

            builder.Property(e => e.Balance)
                                 .IsRequired();


            builder.HasData(
                    new User(1, "Matheus", 1000),
                    new User(2, "Amanda", 10)
);

       }
    }
}
