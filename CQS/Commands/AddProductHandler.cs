namespace WorldImporters.CQS.Commands;

public sealed class AddProductHandler(
    IProductRepository productRepo,
    IImageServiceProcessor imageService) : ICommandHandler<AddProduct>
{
    public async Task Handle(AddProduct command)
    {
        Product productToCreate = command.Product;
        productToCreate.ImagePath = await imageService.ProcessImageAsync(command.Product.ImageFile);

        await productRepo.CreateAsync(productToCreate);
    }
}

public sealed record AddProduct(ProductCreateVM Product) : IRequest;
