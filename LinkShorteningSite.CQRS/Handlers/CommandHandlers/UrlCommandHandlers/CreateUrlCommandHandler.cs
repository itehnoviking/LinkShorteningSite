using AutoMapper;
using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.Data;
using LinkShorteningSite.Data.Entities;
using MediatR;

namespace LinkShorteningSite.CQRS.Handlers.CommandHandlers.UrlCommandHandler;

public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly LinkShorteningSiteContext _database;

    public CreateUrlCommandHandler(LinkShorteningSiteContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
    {
        var url = _mapper.Map<Url>(request);

        await _database.AddAsync(url, cancellationToken: cancellationToken);
        await _database.SaveChangesAsync(cancellationToken: cancellationToken);

        return true;
    }
}