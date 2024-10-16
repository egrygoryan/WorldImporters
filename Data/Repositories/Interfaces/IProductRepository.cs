namespace WorldImporters.Data.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetAsync(int? id);
    Task<IEnumerable<ProductDTO>> GetRangeAsync(int range);
    Task UpdateAsync(Product product);
    Task CreateAsync(Product product);
}
