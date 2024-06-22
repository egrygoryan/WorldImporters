namespace WorldImporters.Data.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetAsync(int? id);
    Task<IEnumerable<Product>> GetRangeAsync(int range);
    Task UpdateAsync(Product product);
}
