namespace WorldImporters.Pages.ProductPage;

public class IndexModel(
    IQueryHandler<GetRangeProducts,
        IEnumerable<ProductDTO>> query) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int MaxProducts { get; set; } = 0;
    public IList<ProductIndexVM> Products { get; private set; } = [];

    public async Task OnGetAsync()
    {
        var products = await query.Handle(new GetRangeProducts(MaxProducts));

        Products = ProductIndexVM.ConvertFromProducts(products);
    }
}
