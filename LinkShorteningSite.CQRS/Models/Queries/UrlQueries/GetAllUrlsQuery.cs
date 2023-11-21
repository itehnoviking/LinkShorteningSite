using LinkShorteningSite.Core.DTOs;
using MediatR;

namespace LinkShorteningSite.CQRS.Models.Queries.UrlQueries;

public class GetAllUrlsQuery : IRequest<IEnumerable<UrlDto>>
{
    
}