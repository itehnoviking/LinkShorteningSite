using LinkShorteningSite.CQRS.Models.Queries.UrlQueries;
using LinkShorteningSite.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShorteningSite.CQRS.Handlers.QueryHandler.UrlQueryHandlers;

public class CheckingShortUrlInDatabaseQueryHandler : IRequestHandler<CheckingShortUrlInDatabaseQuery, bool>
{
    private readonly LinkShorteningSiteContext _database;

    public CheckingShortUrlInDatabaseQueryHandler(LinkShorteningSiteContext database)
    {
        _database = database;
    }

    public async Task<bool> Handle(CheckingShortUrlInDatabaseQuery request, CancellationToken cancellationToken)
    {
        var url = await _database.Urls
            .AsNoTracking()
            .Where(u => u.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (url.ShortUrl != request.ShortUrl)
        {
            var result = _database.Urls
                .AsNoTracking()
                .Select(u => u.ShortUrl)
                .Contains(request.ShortUrl);

            return result;
        }

        return false;
    }
}