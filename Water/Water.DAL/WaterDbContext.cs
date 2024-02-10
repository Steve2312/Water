using Microsoft.EntityFrameworkCore;
using Water.DAL.Mappings;
using Water.DAL.Models;

namespace Water.DAL;

public class WaterDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; init; } = null!;
    public virtual DbSet<Consumption> Consumptions { get; init; } = null!;
    public virtual DbSet<SubjectUserMap> SubjectUserMaps { get; init; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ConsumptionConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectUserMapConfiguration());
    }
}