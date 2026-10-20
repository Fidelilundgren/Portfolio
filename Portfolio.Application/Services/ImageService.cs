using Portfolio.Application.Interfaces;

namespace Portfolio.Application.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    private readonly string[] _allowedExtensions = [".jpg", ".jpeg", ".webp", ".png", ".gif"];
    public long MaxFileSize => 1024 * 1024 * 4;

    public string? Validate(string fileName, long size)
    {
        var extension = Path.GetExtension(fileName).ToLower();

        if (!_allowedExtensions.Contains(extension))
        {
            return "Only jpg, jpeg, png, webp and gif are allowed";
        }

        if (size > MaxFileSize)
        {
            return "Image can be maximum 4 MB";
        }
        return null;
    }

    public async Task<string> SaveAsync(Stream stream, string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLower();

        return await _imageRepository.SaveAsync(stream, extension);
    }
}
