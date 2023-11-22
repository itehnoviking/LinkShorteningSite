using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShorteningSite.CQRS.Handlers.CommandHandlers.UrlCommandHandler;

public class JumpCounterAndReturnFullUrlCommandHandler : IRequestHandler<JumpCounterAndReturnFullUrlCommand, string>
{
    private readonly LinkShorteningSiteContext _database;

    public JumpCounterAndReturnFullUrlCommandHandler(LinkShorteningSiteContext database)
    {
        _database = database;
    }

    public async Task<string> Handle(JumpCounterAndReturnFullUrlCommand request, CancellationToken cancellationToken)
    {
        var url = await _database.Urls
            .Where(u => u.ShortUrl.Equals(request.ShortUrl))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        url.JumpCounter++;
        await _database.SaveChangesAsync(cancellationToken: cancellationToken);

        return url.FullUrl;
    }
}