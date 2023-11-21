using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShorteningSite.CQRS.Handlers.CommandHandlers.UrlCommandHandler;

public class DeleteUrlByIdCommandHandler : IRequestHandler<DeleteUrlByIdCommand, bool>
{
    private readonly LinkShorteningSiteContext _database;

    public DeleteUrlByIdCommandHandler(LinkShorteningSiteContext database)
    {
        _database = database;
    }

    public async Task<bool> Handle(DeleteUrlByIdCommand request, CancellationToken cancellationToken)
    {
        var url = await _database.Urls
            .AsNoTracking()
            .Where(u => u.Id.Equals(request.Id)).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        _database.Urls.Remove(url);

        await _database.SaveChangesAsync(cancellationToken: cancellationToken);

        return true;
    }
}