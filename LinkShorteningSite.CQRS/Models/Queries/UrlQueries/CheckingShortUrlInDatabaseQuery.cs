using MediatR;

namespace LinkShorteningSite.CQRS.Models.Queries.UrlQueries;

public class CheckingShortUrlInDatabaseQuery : IRequest<bool>
{
    public CheckingShortUrlInDatabaseQuery(int id, string shortUrl)
    {
        Id = id;
        ShortUrl = shortUrl;
    }

    public int Id { get; set; }
    public string ShortUrl { get; set; }
}