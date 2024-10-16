using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WorldImporters.Services;

public sealed class ImageResizeProcessor(
    IOptions<ImageSettings> imgSettings) : IImageServiceProcessor
{
    private readonly ImageSettings _imgSettings = imgSettings.Value;

    public async Task<string> ProcessImageAsync(IFormFile image)
    {
        var extension = Path.GetExtension(image.FileName);
        if (!_imgSettings.Extensions.Contains(extension))
        {
            throw new ArgumentException($"Not supported extension type");
        }

        var customFileName = Path.GetRandomFileName()
            .Replace(".", string.Empty)
            + extension;
        var absPath = Path.Combine(_imgSettings.Path, customFileName);

        using (var stream = image.OpenReadStream())
        {
            using (var fileStream = new FileStream(absPath, FileMode.Create))
            {
                if (stream.Length > _imgSettings.MaxSize)
                {
                    using var img = Image.Load(stream);
                    img.Mutate(x => x.Resize(new Size(_imgSettings.Width, _imgSettings.Height)));
                    try
                    {
                        await img.SaveAsync(fileStream, img.Metadata.DecodedImageFormat);
                    }
                    catch (ArgumentNullException)
                    {
                        throw;
                    }
                }
                else
                {
                    await image.CopyToAsync(fileStream);
                }
            };
        }

        return absPath;
    }
}
