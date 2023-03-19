using Microsoft.EntityFrameworkCore;
using ShopBridge.Core.Entities;

namespace ShopBridge.Data;
public class ShopBridgeContext : DbContext
{
    public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCategoryMapping();
        modelBuilder.AddProductMapping();

        base.OnModelCreating(modelBuilder);
    }

    public Task<int> SaveChangesWithTimestampsAsync(CancellationToken cancellationToken = default)
    {
        var addedOrUpdatedEntries = ChangeTracker.Entries<BaseEntity>().Where(e => e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in addedOrUpdatedEntries)
            entityEntry.Entity.UpdatedAt = DateTime.Now;

        return base.SaveChangesAsync(cancellationToken);
    }
}
