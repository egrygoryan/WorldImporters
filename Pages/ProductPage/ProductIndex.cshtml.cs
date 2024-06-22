namespace WorldImporters.Pages.ProductPage;

public class IndexModel(
    IProductRepository repo,
    ILogger<IndexModel> logger) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int MaxProducts { get; set; } = 0;
    public IList<ProductIndexVM> Products { get; private set; } = [];

    public async Task OnGetAsync()
    {
        var products = await repo.GetRangeAsync(MaxProducts);
        logger.LogInformation($"Max. products limit is {MaxProducts}");

        Products = products
            .Select(x => new ProductIndexVM
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued,
                CategoryName = x.Category?.CategoryName
                               ?? "N/A",
                SupplierName = x.Supplier?.CompanyName
                               ?? "N/A"
            })
            .ToList();
    }
}
