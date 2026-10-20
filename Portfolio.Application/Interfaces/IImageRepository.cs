namespace Portfolio.Application.Interfaces;

public interface IImageRepository
{
    Task<string> SaveAsync(Stream stream, string extension);
}
