
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
 
    public DbSet<CustomerEntity> Customers { get; set; } = null!;

    public DbSet<ProductEntity> Products { get; set; } = null!;

    public DbSet<ProjectEntity> Projects { get; set; } = null!;

    public DbSet<StatusType> StatusTypes { get; set; } = null!;

    public DbSet<UserEntity> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfiguration för UserEntity
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
        });

        // Konfiguration för ProjectEntity
        modelBuilder.Entity<ProjectEntity>(entity =>
        {
            entity.HasKey(e => e.ProjectId);
            entity.Property(e => e.ProjectName).IsRequired();
            //entity.Property(e => e.).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Status).IsRequired();

            // Relation mellan projekt och användare (projektansvarig)
            entity.HasOne(e => e.ResponsibleUser)
                  .WithMany()
                  .HasForeignKey(e => e.ResponsibleUserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}