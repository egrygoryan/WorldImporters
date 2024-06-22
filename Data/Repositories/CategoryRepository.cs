namespace WorldImporters.Data.Repositories;

public class CategoryRepository(WorldImportersContext ctx) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync() =>
        await ctx.Categories.ToListAsync();
}
