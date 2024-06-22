namespace WorldImporters.Data.Configuration;

public class SummaryOfSalesByYearConfiguration : IEntityTypeConfiguration<SummaryOfSalesByYear>
{
    public void Configure(EntityTypeBuilder<SummaryOfSalesByYear> builder)
    {
        builder
            .HasNoKey()
            .ToView("Summary of Sales by Year");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.ShippedDate).HasColumnType("datetime");
        builder.Property(e => e.Subtotal).HasColumnType("money");
    }
}
