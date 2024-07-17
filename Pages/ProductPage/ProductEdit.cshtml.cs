namespace WorldImporters.Pages.ProductPage;

public class EditModel(
    IProductRepository productRepo,
    ICategoryRepository categoryRepo,
    ISupplierRepository supplierRepo) : PageModel
{
    [BindProperty]
    public ProductEditVM Product { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await productRepo.GetAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        Product = product;

        var categoriesAwaiter = await categoryRepo.GetAllAsync();
        var categories = categoriesAwaiter.Select(x => new { x.CategoryId, x.CategoryName });

        var suppliersAwaiter = await supplierRepo.GetAllAsync();
        var suppliers = suppliersAwaiter.Select(x => new { x.SupplierId, x.CompanyName })
                                        .OrderBy(x => x.CompanyName);

        ViewData["Categories"] = new SelectList(categories, "CategoryId", "CategoryName");
        ViewData["Suppliers"] = new SelectList(suppliers, "SupplierId", "CompanyName");

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Product productToUpdate = Product;

        try
        {
            await productRepo.UpdateAsync(productToUpdate);
        } catch (DbUpdateConcurrencyException)
        {
            if (await ProductExists(productToUpdate.ProductId))
            {
                return NotFound();
            } else
            {
                throw;
            }
        }

        return RedirectToPage("./ProductIndex");
    }

    private async Task<bool> ProductExists(int id)
    {
        var product = await productRepo.GetAsync(id);

        return product is null;
    }
}
