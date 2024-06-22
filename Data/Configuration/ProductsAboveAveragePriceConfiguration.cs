﻿namespace WorldImporters.Data.Configuration;

public class ProductsAboveAveragePriceConfiguration : IEntityTypeConfiguration<ProductsAboveAveragePrice>
{
    public void Configure(EntityTypeBuilder<ProductsAboveAveragePrice> builder)
    {
        builder
            .HasNoKey()
            .ToView("Products Above Average Price");

        builder.Property(e => e.ProductName).HasMaxLength(40);
        builder.Property(e => e.UnitPrice).HasColumnType("money");
    }
}
