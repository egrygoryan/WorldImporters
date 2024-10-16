namespace WorldImporters.Data.Repositories;

public class CategoryRepository(WorldImportersContext ctx) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await ctx.Categories
            .Select(x => new Category
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture,
            })
            .ToListAsync();
}
