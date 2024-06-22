﻿namespace WorldImporters.Data.Configuration;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(e => e.RegionId).IsClustered(false);

        builder.ToTable("Region");

        builder.Property(e => e.RegionId)
            .ValueGeneratedNever()
            .HasColumnName("RegionID");
        builder.Property(e => e.RegionDescription)
            .HasMaxLength(50)
            .IsFixedLength();
    }
}
