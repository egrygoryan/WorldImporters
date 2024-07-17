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

        Products = ProductIndexVM.ConvertFromCategory(products);
    }
}
