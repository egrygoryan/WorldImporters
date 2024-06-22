namespace WorldImporters.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(e => e.CategoryId, "CategoriesProducts");

        builder.HasIndex(e => e.CategoryId, "CategoryID");

        builder.HasIndex(e => e.ProductName, "ProductName");

        builder.HasIndex(e => e.SupplierId, "SupplierID");

        builder.HasIndex(e => e.SupplierId, "SuppliersProducts");

        builder.Property(e => e.ProductId).HasColumnName("ProductID");
        builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
        builder.Property(e => e.ProductName).HasMaxLength(40);
        builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        builder.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
        builder.Property(e => e.SupplierId).HasColumnName("SupplierID");
        builder.Property(e => e.UnitPrice)
            .HasDefaultValue(0m)
            .HasColumnType("money");
        builder.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
        builder.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

        builder.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("FK_Products_Categories");

        builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
            .HasForeignKey(d => d.SupplierId)
            .HasConstraintName("FK_Products_Suppliers");
    }
}
