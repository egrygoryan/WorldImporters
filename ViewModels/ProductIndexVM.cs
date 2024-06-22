using System.ComponentModel.DataAnnotations;

namespace WorldImporters.ViewModels;

public class ProductIndexVM
{
    public int ProductId { get; set; }

    [Display(Name = "Product name")]
    public string ProductName { get; set; } = default!;

    [Display(Name = "Quantity per unit")]
    public string? QuantityPerUnit { get; set; }

    [Display(Name = "Unit price")]
    public decimal? UnitPrice { get; set; }

    [Display(Name = "Units in stock")]
    public short? UnitsInStock { get; set; }

    [Display(Name = "Units on order")]
    public short? UnitsOnOrder { get; set; }

    [Display(Name = "Reorder level")]
    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    [Display(Name = "Category")]
    public string CategoryName { get; set; } = default!;

    [Display(Name = "Supplier")]
    public string SupplierName { get; set; } = default!;
}