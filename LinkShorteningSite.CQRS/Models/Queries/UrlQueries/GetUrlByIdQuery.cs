using LinkShorteningSite.Core.DTOs;
using MediatR;

namespace LinkShorteningSite.CQRS.Models.Queries.UrlQueries;

public class GetUrlByIdQuery : IRequest<UrlDto>
{
    public GetUrlByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}