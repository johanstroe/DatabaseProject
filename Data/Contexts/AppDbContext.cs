
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
    public DbSet<ProjectEntity> Projects { get; set; } = null!;
   
    public DbSet<CustomerEntity> Customers { get; set; } = null!;

    public DbSet<ProductEntity> Products { get; set; } = null!;

    public DbSet<EmployeeEntity> Employees { get; set; } = null!;

    public DbSet<ProjectStatusEntity> Statuses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.CustomerId);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Product)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(p => p.Employee)
            .WithMany(c => c.Projects)
            .HasForeignKey(p => p.EmployeeId);
    }
}