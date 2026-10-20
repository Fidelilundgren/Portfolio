using Portfolio.Application.Interfaces;

namespace Portfolio.Infrastructure.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly string _imagePath;

    public ImageRepository(string webRootPath)
    {
        _imagePath = Path.Combine(webRootPath, "userImages");
    }

    public async Task<string> SaveAsync(Stream stream, string extension)
    {
        Directory.CreateDirectory(_imagePath);

        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(_imagePath, fileName);

        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return $"/userImages/{fileName}";
    }
}
