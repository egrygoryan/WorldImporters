namespace WorldImporters.Services.Interfaces;

public interface IImageServiceProcessor
{
    Task<ErrorOr<string>> ProcessImageAsync(IFormFile image);
}