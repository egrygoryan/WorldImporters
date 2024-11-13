namespace WorldImporters.CQS.Commands;

public sealed class EditProductHandler(
    IProductRepository productRepo,
    IImageServiceProcessor imageService)
    : ICommandHandler<EditProduct, Updated>
{
    public async Task<ErrorOr<Updated>> Handle(EditProduct command)
    {
        Product productToUpdate = command.Product;
        var result = await imageService.ProcessImageAsync(command.Product.ImageFile);

        if (result.IsError)
        {
            return result.FirstError;
        }

        productToUpdate.ImagePath = result.Value;
        await productRepo.UpdateAsync(productToUpdate);

        return Result.Updated;
    }
}

public sealed record EditProduct(ProductEditVM Product) : IRequest;
