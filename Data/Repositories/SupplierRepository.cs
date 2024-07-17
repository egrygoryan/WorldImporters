namespace WorldImporters.Data.Repositories;

public class SupplierRepository(WorldImportersContext ctx) : ISupplierRepository
{
    public async Task<IEnumerable<Supplier>> GetAllAsync() =>
        await ctx.Suppliers
            .Select(x => new Supplier
            {
                SupplierId = x.SupplierId,
                CompanyName = x.CompanyName,
            })
            .ToListAsync();
}
