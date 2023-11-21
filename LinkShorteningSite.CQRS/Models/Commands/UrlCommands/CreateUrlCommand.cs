using LinkShorteningSite.Core.DTOs;
using MediatR;

namespace LinkShorteningSite.CQRS.Models.Commands.UrlCommands;

public class CreateUrlCommand : IRequest<bool>
{
    public CreateUrlCommand(UrlDto dto, string shortUrl)
    {
        FullUrl = dto.FullUrl;
        ShortUrl = shortUrl;
        DateCreated = dto.DateCreated;
        JumpCounter = dto.JumpCounter;
    }

    public string FullUrl { get; set; }
    public string ShortUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public int JumpCounter { get; set; }
}