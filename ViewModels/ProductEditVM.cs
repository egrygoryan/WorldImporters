using System.ComponentModel.DataAnnotations;

namespace WorldImporters.ViewModels;

public class ProductEditVM
{
    public int ProductId { get; set; }

    [Display(Name = "Product name")]
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 30 characters")]
    [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Product name must contain only letters")]
    public string ProductName { get; set; } = default!;

    [Display(Name = "Quantity per unit")]
    [RegularExpression(@"^[a-zA-Z0-9\s\-*.,;]*$", ErrorMessage = "Invalid characters for quantity")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Quantity value must be between 3 and 20 characters")]
    public string? QuantityPerUnit { get; set; }

    [Display(Name = "Unit price")]
    [Range(0, (double)decimal.MaxValue, ErrorMessage = "Price value is out of range")]
    public decimal? UnitPrice { get; set; }

    [Display(Name = "Units in stock")]
    [Range(0, short.MaxValue, ErrorMessage = "Value is out of range")]
    public short? UnitsInStock { get; set; }

    [Display(Name = "Units on order")]
    [Range(0, short.MaxValue, ErrorMessage = "Value is out of range")]
    public short? UnitsOnOrder { get; set; }

    [Display(Name = "Reorder level")]
    [Range(0, short.MaxValue, ErrorMessage = "Value is out of range")]
    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    [Display(Name = "Supplier")]
    public int SupplierId { get; set; }

    public static implicit operator ProductEditVM(Product product) =>
        new()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            QuantityPerUnit = product.QuantityPerUnit,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
            UnitsOnOrder = product.UnitsOnOrder,
            ReorderLevel = product.ReorderLevel,
            Discontinued = product.Discontinued,
            CategoryId = product.CategoryId ?? default,
            SupplierId = product.SupplierId ?? default,
        };
}
