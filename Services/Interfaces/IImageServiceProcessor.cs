namespace WorldImporters.Services.Interfaces;

public interface IImageServiceProcessor
{
    Task<string> ProcessImageAsync(IFormFile image);
}
