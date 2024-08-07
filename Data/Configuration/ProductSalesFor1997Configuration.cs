﻿namespace WorldImporters.Data.Configuration;

public class ProductSalesFor1997Configuration : IEntityTypeConfiguration<ProductSalesFor1997>
{
    public void Configure(EntityTypeBuilder<ProductSalesFor1997> builder)
    {
        builder
            .HasNoKey()
            .ToView("Product Sales for 1997");

        builder.Property(e => e.CategoryName).HasMaxLength(15);
        builder.Property(e => e.ProductName).HasMaxLength(40);
        builder.Property(e => e.ProductSales).HasColumnType("money");
    }
}
