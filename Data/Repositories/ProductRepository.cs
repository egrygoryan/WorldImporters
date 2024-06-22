namespace WorldImporters.Data.Repositories;

public class ProductRepository(WorldImportersContext ctx) : IProductRepository
{
    public async Task<Product?> GetAsync(int? id) =>
        await ctx
            .Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(m => m.ProductId == id);

    public async Task<IEnumerable<Product>> GetRangeAsync(int range)
    {
        var productQuery = ctx.Products
            .Include(x => x.Category)
            .Include(x => x.Supplier);

        var products = range > 0
            ? productQuery.Take(range)
            : productQuery;

        return await products.ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        ctx.Attach(product).State = EntityState.Modified;
        await ctx.SaveChangesAsync();
    }
}
