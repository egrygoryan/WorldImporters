namespace WorldImporters.Pages.ProductPage;

public class EditModel(
    ICategoryRepository categoryRepo,
    ISupplierRepository supplierRepo,
    ICommandHandler<EditProduct> command,
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

        //apply Result class, to check whether it succeed
        //move this check to command/query handlers
        if (product is null)
        {
            return NotFound();
        }

        Product = product;

        await SeedDropdowns();

        return Page();
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

        await command.Handle(new EditProduct(Product));

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
