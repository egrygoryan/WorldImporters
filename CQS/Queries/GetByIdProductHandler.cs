namespace WorldImporters.CQS.Queries;

public sealed class GetByIdProductHandler(IProductRepository productRepo)
    : IQueryHandler<GetByIdProduct, Product?>
{
    public async Task<ErrorOr<Product?>> Handle(GetByIdProduct query)
    {
        var product = await productRepo.GetAsync(query.Id);

        if (product is null)
        {
            return Error.NotFound(description: $"Product with id {query.Id} doesn't exist");
        }

        return product;
    }
}

public sealed record GetByIdProduct(int? Id);