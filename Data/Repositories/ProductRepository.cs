namespace WorldImporters.Data.Repositories;

public class ProductRepository(WorldImportersContext ctx) : IProductRepository
{
    public async Task<Product?> GetAsync(int? id) =>
        await ctx
            .Products
            .FirstOrDefaultAsync(x => x.ProductId == id);

    public async Task<IEnumerable<ProductDTO>> GetRangeAsync(int range)
    {
        var productQuery = ctx.Products
            .Include(x => x.Category)
            .Include(x => x.Supplier)
            .Select(x => new ProductDTO(
                x.ProductId,
                x.ProductName,
                x.SupplierId,
                x.Supplier.CompanyName,
                x.CategoryId,
                x.Category.CategoryName,
                x.QuantityPerUnit,
                x.UnitPrice,
                x.UnitsInStock,
                x.UnitsOnOrder,
                x.ReorderLevel,
                x.Discontinued));

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
