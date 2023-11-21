using MediatR;

namespace LinkShorteningSite.CQRS.Models.Commands.UrlCommands;

public class UpdateUrlCommand : IRequest<bool>
{
    public UpdateUrlCommand(int id, string shortUrl, DateTime dateCreated)
    {
        Id = id;
        ShortUrl = shortUrl;
        DateCreated = dateCreated;
    }

    public int Id { get; set; }
    public string ShortUrl { get; set; }
    public DateTime DateCreated { get; set; }
}