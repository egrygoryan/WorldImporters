namespace WorldImporters.Configuration;

public static class WorldImportersConfigurationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, string connectionName)
    {
        var connection = Environment.GetEnvironmentVariable(connectionName);

        return services
            .AddDbContext<WorldImportersContext>(
                options => options.UseSqlServer(connection))
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ISupplierRepository, SupplierRepository>();
    }
}
