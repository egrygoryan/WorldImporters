using Microsoft.Extensions.FileProviders;

namespace WorldImporters.Configuration;

public static class StaticFilesConfigurationExtension
{
    public static IApplicationBuilder AddStaticImages(this WebApplication app)
    {
        var imageSettings = app.Services.GetRequiredService<IOptions<ImageSettings>>().Value;

        return app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(imageSettings.Path),
            RequestPath = imageSettings.RequestPath
        });
    }
}