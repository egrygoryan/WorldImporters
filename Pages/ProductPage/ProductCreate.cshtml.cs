namespace WorldImporters.Pages.ProductPage;

public class ProductCreateModel(
    IProductRepository productRepo,
    ICategoryRepository categoryRepo,
    ISupplierRepository supplierRepo,
    IImageServiceProcessor imageService) : PageModel
{
    [BindProperty]
    public ProductCreateVM Product { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        var categoriesAwaiter = await categoryRepo.GetAllAsync();
        var categories = categoriesAwaiter.Select(x => new { x.CategoryId, x.CategoryName });

        var suppliersAwaiter = await supplierRepo.GetAllAsync();
        var suppliers = suppliersAwaiter.Select(x => new { x.SupplierId, x.CompanyName })
                                        .OrderBy(x => x.CompanyName);

        ViewData["Categories"] = new SelectList(categories, "CategoryId", "CategoryName");
        ViewData["Suppliers"] = new SelectList(suppliers, "SupplierId", "CompanyName");

        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Product productToCreate = Product;

        try
        {
            productToCreate.ImagePath = await imageService.ProcessImageAsync(Product.ImageFile);
        }
        catch (ArgumentNullException)
        {
            return StatusCode(500, new { Message = "Internal Server Error" });
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }

        await productRepo.CreateAsync(productToCreate);

        return RedirectToPage("./ProductIndex");
    }
}
