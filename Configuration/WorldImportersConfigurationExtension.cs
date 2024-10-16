namespace WorldImporters.Configuration;

public static class WorldImportersConfigurationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, string connection)
    {
        return services
            .AddDbContext<WorldImportersContext>(
                options => options.UseSqlServer(connection))
            .AddSingleton<IImageServiceProcessor, ImageResizeProcessor>()
                .Decorate<IImageServiceProcessor, DefaultImageProcessor>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ISupplierRepository, SupplierRepository>();
    }
}
