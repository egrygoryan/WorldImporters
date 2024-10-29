namespace WorldImporters.CQS.Queries;

public sealed class GetRangeProductHandler(
    IProductRepository productRepo,
    ILogger<GetRangeProductHandler> logger)
    : IQueryHandler<GetRangeProducts, IEnumerable<ProductDTO>>
{
    public async Task<IEnumerable<ProductDTO>> Handle(GetRangeProducts query)
    {
        logger.LogInformation($"Max. products limit is {query.Range}");

        return await productRepo.GetRangeAsync(query.Range);
    }
}

public sealed record GetRangeProducts(int Range);
