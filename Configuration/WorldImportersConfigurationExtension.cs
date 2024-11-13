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
            .AddScoped<ISupplierRepository, SupplierRepository>()
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime())
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
    }
}
