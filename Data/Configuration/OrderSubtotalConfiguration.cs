namespace WorldImporters.Data.Configuration;

public class OrderSubtotalConfiguration : IEntityTypeConfiguration<OrderSubtotal>
{
    public void Configure(EntityTypeBuilder<OrderSubtotal> builder)
    {
        builder
            .HasNoKey()
            .ToView("Order Subtotals");

        builder.Property(e => e.OrderId).HasColumnName("OrderID");
        builder.Property(e => e.Subtotal).HasColumnType("money");
    }
}
