using AutoMapper;
using LinkShorteningSite.Core.DTOs;
using LinkShorteningSite.CQRS.Models.Queries.UrlQueries;
using LinkShorteningSite.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShorteningSite.CQRS.Handlers.QueryHandler.UrlQueryHandlers;

public class GetUrlByIdQueryHandler : IRequestHandler<GetUrlByIdQuery, UrlDto>
{
    private readonly LinkShorteningSiteContext _database;
    private readonly IMapper _mapper;

    public GetUrlByIdQueryHandler(LinkShorteningSiteContext database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public async Task<UrlDto> Handle(GetUrlByIdQuery request, CancellationToken cancellationToken)
    {
        var url = await _database.Urls
            .AsNoTracking()
            .Where(u => u.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var urlDto = _mapper.Map<UrlDto>(url);

        return urlDto;
    }
}