namespace WorldImporters.Data.Repositories;

public class SupplierRepository(WorldImportersContext ctx) : ISupplierRepository
{
    public async Task<IEnumerable<Supplier>> GetAllAsync() =>
        await ctx.Suppliers.ToListAsync();
}
