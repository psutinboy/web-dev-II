using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureApplicationUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");
                
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.Role).HasColumnName("Role");
                entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");
                entity.Property(e => e.LastLogin).HasColumnName("LastLogin");
            });
        }
    }
} 