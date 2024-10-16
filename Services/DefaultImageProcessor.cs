namespace WorldImporters.Services;

public sealed class DefaultImageProcessor(
    IOptions<ImageSettings> imageSettings,
    IImageServiceProcessor imgProcessor) : IImageServiceProcessor
{
    private readonly ImageSettings _imageSettings = imageSettings.Value;

    public async Task<string> ProcessImageAsync(IFormFile image)
    {
        if (!Directory.Exists(_imageSettings.Path))
        {
            Directory.CreateDirectory(_imageSettings.Path);
        }

        return image is null
            ? Path.Combine(_imageSettings.Path, _imageSettings.Default)
            : await imgProcessor.ProcessImageAsync(image);
    }
}
