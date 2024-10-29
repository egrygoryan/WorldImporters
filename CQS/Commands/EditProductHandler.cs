namespace WorldImporters.CQS.Commands;

public sealed class EditProductHandler(
    IProductRepository productRepo,
    IImageServiceProcessor imageService) : ICommandHandler<EditProduct>
{
    public async Task Handle(EditProduct command)
    {
        Product productToUpdate = command.Product;
        productToUpdate.ImagePath = await imageService.ProcessImageAsync(command.Product.ImageFile);

        await productRepo.UpdateAsync(productToUpdate);
    }
}

public sealed record EditProduct(ProductEditVM Product) : IRequest;
