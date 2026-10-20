namespace Portfolio.Application.Interfaces;

public interface IImageService
{
    long MaxFileSize { get; }
    string? Validate(string fileName, long size);
    Task<string> SaveAsync(Stream stream, string fileName);
}
