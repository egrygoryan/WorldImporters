﻿namespace WorldImporters.Data.Configuration;

public class QuarterlyOrderConfiguration : IEntityTypeConfiguration<QuarterlyOrder>
{
    public void Configure(EntityTypeBuilder<QuarterlyOrder> builder)
    {
        builder
            .HasNoKey()
            .ToView("Quarterly Orders");

        builder.Property(e => e.City).HasMaxLength(15);
        builder.Property(e => e.CompanyName).HasMaxLength(40);
        builder.Property(e => e.Country).HasMaxLength(15);
        builder.Property(e => e.CustomerId)
            .HasMaxLength(5)
            .IsFixedLength()
            .HasColumnName("CustomerID");
    }
}
