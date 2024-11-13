namespace WorldImporters.Pages.ProductPage;

public class EditModel(
    ICategoryRepository categoryRepo,
    ISupplierRepository supplierRepo,
    ICommandHandler<EditProduct, Updated> command,
    IQueryHandler<GetByIdProduct, Product?> query) : PageModel
{
    [BindProperty]
    public ProductEditVM Product { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await query.Handle(new GetByIdProduct(id));
        await SeedDropdowns();

        //strangely sw exp produces if(true); x2 op + ternary operator
        //but sw statement only if / else
        return product.IsError switch
        {
            true => NotFound(product.FirstError.Description),
            _ => HandleSuccess(product)
        };
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await SeedDropdowns();
            return Page();
        }

        var response = await command.Handle(new EditProduct(Product));

        return response.IsError switch
        {
            true => BadRequest(response.FirstError.Description),
            _ => RedirectToPage("./ProductIndex"),
        };
    }

    private PageResult HandleSuccess(ErrorOr<Product?> product)
    {
        Product = product.Value;
        return Page();
    }

    private async Task SeedDropdowns()
    {
        var categoriesAwaiter = await categoryRepo.GetAllAsync();
        var categories = categoriesAwaiter.Select(x => new { x.CategoryId, x.CategoryName });

        var suppliersAwaiter = await supplierRepo.GetAllAsync();
        var suppliers = suppliersAwaiter.Select(x => new { x.SupplierId, x.CompanyName })
                                        .OrderBy(x => x.CompanyName);

        ViewData["Categories"] = new SelectList(categories, "CategoryId", "CategoryName");
        ViewData["Suppliers"] = new SelectList(suppliers, "SupplierId", "CompanyName");
    }
}
