using AutoMapper;
using LinkShorteningSite.Core.DTOs;
using LinkShorteningSite.CQRS.Models.Queries.UrlQueries;
using LinkShorteningSite.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShorteningSite.CQRS.Handlers.QueryHandler.UrlQueryHandlers;

public class GetAllUrlsQueryHandler : IRequestHandler<GetAllUrlsQuery, IEnumerable<UrlDto>>
{
    private readonly LinkShorteningSiteContext _database;
    private readonly IMapper _mapper;

    public GetAllUrlsQueryHandler(LinkShorteningSiteContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UrlDto>> Handle(GetAllUrlsQuery request, CancellationToken cancellationToken)
    {
        var urls = await _database.Urls
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return _mapper.Map<IEnumerable<UrlDto>>(urls);
    }
}