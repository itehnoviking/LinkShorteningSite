using LinkShorteningSite.Core.DTOs;

namespace LinkShorteningSite.Core.Interfaces.Services;

public interface IUrlService
{
    Task CreateUrlAsync(UrlDto urlDto);
    Task<IEnumerable<UrlDto>> GetAllUrlsAsync();
    Task<UrlDto> GetUrlByIdAsync(int id);
    Task DeleteUrlByIdAsync(int id);
    Task UpdateUrlAsync(int id, string shortUrl, DateTime dateCreated);
}