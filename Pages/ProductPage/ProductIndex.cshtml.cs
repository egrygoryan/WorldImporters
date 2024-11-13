namespace WorldImporters.Pages.ProductPage;

public class IndexModel(
    IQueryHandler<GetRangeProducts,
        IEnumerable<ProductDTO>> query) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int MaxProducts { get; set; } = 0;
    public IList<ProductIndexVM> Products { get; private set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var products = await query.Handle(new GetRangeProducts(MaxProducts));

        return products.IsError switch
        {
            true => BadRequest(products.FirstError.Description),
            _ => HandleSuccess(products)
        };
    }

    private PageResult HandleSuccess(ErrorOr<IEnumerable<ProductDTO>> products)
    {
        Products = ProductIndexVM.ConvertFromProducts(products.Value);
        return Page();
    }
}
