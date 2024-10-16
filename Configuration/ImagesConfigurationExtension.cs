namespace WorldImporters.Configuration;

public static class ImagesConfigurationExtension
{
    public static IServiceCollection AddImageConfiguration(this WebApplicationBuilder builder) =>
        builder.Services.Configure<ImageSettings>(
            builder.Configuration.GetSection("ImageSettings"));
}

public sealed class ImageSettings
{
    public string Path { get; set; }
    public string Default { get; set; }
    public int MaxSize { get; set; }
    public List<string> Extensions { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string RequestPath { get; set; }
}
