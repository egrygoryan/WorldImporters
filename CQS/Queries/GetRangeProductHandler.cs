namespace WorldImporters.CQS.Queries;

public sealed class GetRangeProductHandler(
    IProductRepository productRepo,
    ILogger<GetRangeProductHandler> logger)
    : IQueryHandler<GetRangeProducts, IEnumerable<ProductDTO>>
{
    public async Task<ErrorOr<IEnumerable<ProductDTO>>> Handle(GetRangeProducts query)
    {
        if (query.Range < 0)
        {
            return Error.Validation(description: "Products limit can't be less than 0");
        }

        logger.LogInformation($"Max. products limit is {query.Range}");

        var result = await productRepo.GetRangeAsync(query.Range);

        return result.ToErrorOr();
    }
}

public sealed record GetRangeProducts(int Range);
