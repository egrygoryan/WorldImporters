namespace WorldImporters.Pages.ProductPage;

public class ProductCreateModel(
    ICategoryRepository categoryRepo,
    ISupplierRepository supplierRepo,
    ICommandHandler<AddProduct> command) : PageModel
{
    [BindProperty]
    public ProductCreateVM Product { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        await SeedDropdowns();
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        //for trigger modelstate failed, delete name="Product.UnitPrice" attribute
        if (!ModelState.IsValid)
        {
            await SeedDropdowns();
            return Page();
        }

        await command.Handle(new AddProduct(Product));

        return RedirectToPage("./ProductIndex");
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
