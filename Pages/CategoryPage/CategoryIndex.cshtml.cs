namespace WorldImporters.Pages.CategoryPage;

public class IndexModel(ICategoryRepository repo) : PageModel
{
    public IEnumerable<CategoryIndexVM> Categories { get; private set; } = [];
    public async Task OnGetAsync()
    {
        var categories = await repo.GetAllAsync();

        Categories = CategoryIndexVM.ConvertFromCategory(categories);
    }
}
