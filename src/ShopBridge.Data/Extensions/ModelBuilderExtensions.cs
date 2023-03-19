using Microsoft.EntityFrameworkCore;
using ShopBridge.Core.Entities;

namespace System;
public static class ModelBuilderExtensions
{
    public static ModelBuilder AddProductMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Stock)
                .HasDefaultValue(DatabaseConstants.ZeroValue)
                .IsRequired();

            entity.Property(p => p.Price)
                .HasDefaultValue(DatabaseConstants.ZeroValue)
                .IsRequired();

            entity.ToTable(t =>
            {
                t.HasCheckConstraint(DatabaseConstants.CKProductStockName, DatabaseConstants.CKProductStock);
                t.HasCheckConstraint(DatabaseConstants.CKProductPriceName, DatabaseConstants.CKProductPrice);
            });

            entity
                .HasMany(c => c.Categories)
                .WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    DatabaseConstants.ProductsCategoriesName,
                    c => c.HasOne<Category>().WithMany().HasForeignKey(DatabaseConstants.CategoryIdName).OnDelete(DeleteBehavior.ClientSetNull),
                    p => p.HasOne<Product>().WithMany().HasForeignKey(DatabaseConstants.ProductIdName).OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey(DatabaseConstants.ProductIdName, DatabaseConstants.CategoryIdName);
                        j.ToTable(DatabaseConstants.ProductsCategoriesName);
                    }
                );

        }).AddBaseEntityMapping<Product>(DatabaseConstants.DefaultMediumStringMaxLength, DatabaseConstants.DefaultLargeStringMaxLength);

        return modelBuilder;
    }

    public static ModelBuilder AddCategoryMapping(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddBaseEntityMapping<Category>(DatabaseConstants.DefaultMediumStringMaxLength, DatabaseConstants.DefaultLargeStringMaxLength);

        return modelBuilder;
    }

    private static ModelBuilder AddBaseEntityMapping<TEntity>(
        this ModelBuilder modelBuilder,
        int nameMaxLength,
        int descriptionMaxLength) where TEntity : BaseEntity
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        if (nameMaxLength <= 0)
            throw new ArgumentOutOfRangeException(nameof(nameMaxLength));

        if (descriptionMaxLength <= 0)
            throw new ArgumentOutOfRangeException(nameof(descriptionMaxLength));

        modelBuilder.Entity<TEntity>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.HasIndex(b => b.Name).IsUnique();

            entity.HasIndex(b => b.Description).IsUnique();

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(nameMaxLength)
                .IsUnicode(false);

            entity.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(descriptionMaxLength)
                .IsUnicode(false);

            entity.Property(b => b.CreatedAt)
                .IsRequired()
                .HasColumnType(DatabaseConstants.DatetimeColumnTypeName)
                .HasDefaultValueSql(DatabaseConstants.GetDateSqlFunction);

            entity.Property(b => b.UpdatedAt)
                .IsRequired(false)
                .HasColumnType(DatabaseConstants.DatetimeColumnTypeName);
        });

        return modelBuilder;
    }
}
