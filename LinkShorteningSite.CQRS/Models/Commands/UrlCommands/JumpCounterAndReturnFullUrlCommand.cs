using MediatR;

namespace LinkShorteningSite.CQRS.Models.Commands.UrlCommands;

public class JumpCounterAndReturnFullUrlCommand : IRequest<string>
{
    public JumpCounterAndReturnFullUrlCommand(string shortUrl)
    {
        ShortUrl = shortUrl;
    }
    public string ShortUrl { get; set; }
}