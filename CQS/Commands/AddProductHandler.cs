namespace WorldImporters.CQS.Commands;

public sealed class AddProductHandler(
    IProductRepository productRepo,
    IImageServiceProcessor imageService)
    : ICommandHandler<AddProduct, Created>
{
    public async Task<ErrorOr<Created>> Handle(AddProduct command)
    {
        Product productToCreate = command.Product;
        var result = await imageService.ProcessImageAsync(command.Product.ImageFile);

        if (result.IsError)
        {
            return result.FirstError;
        }

        productToCreate.ImagePath = result.Value;
        await productRepo.CreateAsync(productToCreate);

        return Result.Created;
    }
}

public sealed record AddProduct(ProductCreateVM Product) : IRequest;
