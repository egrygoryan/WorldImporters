namespace WorldImporters.Pages.CategoryPage;

public class IndexModel(ICategoryRepository repo) : PageModel
{
    public IEnumerable<CategoryIndexVM> Categories { get; private set; } = [];
    public async Task OnGetAsync()
    {
        var categories = await repo.GetAllAsync();

        Categories = categories
            .Select(x => new CategoryIndexVM(
                CategoryName: x.CategoryName,
                Description: x.Description ?? "No description"));
    }
}
