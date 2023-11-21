using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkShorteningSite.CQRS.Handlers.CommandHandlers.UrlCommandHandler;

public class UpdateUrlCommandHandler : IRequestHandler<UpdateUrlCommand, bool>
{
    private readonly LinkShorteningSiteContext _database;

    public UpdateUrlCommandHandler(LinkShorteningSiteContext database)
    {
        _database = database;
    }

    public async Task<bool> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
    {
        var url = await _database.Urls
            .FindAsync(request.Id);

        url.ShortUrl = request.ShortUrl;
        url.DateCreated = request.DateCreated;

        await _database.SaveChangesAsync(cancellationToken: cancellationToken);

        return true;
    }
}