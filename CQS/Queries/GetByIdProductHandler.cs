namespace WorldImporters.CQS.Queries;

public sealed class GetByIdProductHandler(IProductRepository productRepo)
    : IQueryHandler<GetByIdProduct, Product?>
{
    public async Task<Product?> Handle(GetByIdProduct query)
    {
        return await productRepo.GetAsync(query.Id);
    }
}

public sealed record GetByIdProduct(int? Id);