﻿namespace WorldImporters.Data.Configuration;

public class CategorySalesFor1997Configuration : IEntityTypeConfiguration<CategorySalesFor1997>
{
    public void Configure(EntityTypeBuilder<CategorySalesFor1997> builder)
    {
        builder
            .HasNoKey()
            .ToView("Category Sales for 1997");

        builder.Property(e => e.CategoryName).HasMaxLength(15);
        builder.Property(e => e.CategorySales).HasColumnType("money");
    }
}
