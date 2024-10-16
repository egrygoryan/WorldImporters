namespace WorldImporters.ViewModels;

public class CategoryIndexVM()
{
    public string CategoryName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public byte[] Image { get; set; } = null!;

    public static implicit operator CategoryIndexVM(Category category) =>
        new()
        {
            CategoryName = category.CategoryName,
            Description = category.Description ?? "No description",
            Image = category.Picture.Skip(78).ToArray()
        };

    public static IEnumerable<CategoryIndexVM> ConvertFromCategory(IEnumerable<Category> categories)
    {
        List<CategoryIndexVM> models = [.. categories];
        return models;
    }
}