namespace WorldImporters.Data.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }

    public static implicit operator Product(ProductEditVM model) =>
        new()
        {
            ProductId = model.ProductId,
            ProductName = model.ProductName,
            QuantityPerUnit = model.QuantityPerUnit,
            UnitPrice = model.UnitPrice,
            UnitsInStock = model.UnitsInStock,
            UnitsOnOrder = model.UnitsOnOrder,
            ReorderLevel = model.ReorderLevel,
            Discontinued = model.Discontinued,
            CategoryId = model.CategoryId,
            SupplierId = model.SupplierId,
        };

    public static implicit operator Product(ProductCreateVM model) =>
        new()
        {
            ProductName = model.ProductName,
            QuantityPerUnit = model.QuantityPerUnit,
            UnitPrice = model.UnitPrice,
            UnitsInStock = model.UnitsInStock,
            UnitsOnOrder = model.UnitsOnOrder,
            ReorderLevel = model.ReorderLevel,
            Discontinued = model.Discontinued,
            CategoryId = model.CategoryId,
            SupplierId = model.SupplierId
        };
}
