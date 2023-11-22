using System.Runtime.InteropServices;
using AutoMapper;
using LinkShorteningSite.Core.DTOs;
using LinkShorteningSite.Core.Interfaces.Services;
using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.CQRS.Models.Queries.UrlQueries;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace LinkShorteningSite.Domain.Services;

public class UrlService : IUrlService
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;

    public UrlService(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    public async Task CreateUrlAsync(UrlDto dto)
    {
        var shortUrl = GenerateShortUrl(_configuration["ApplicationVariables:Salt"]);

        await _mediator.Send(new CreateUrlCommand(dto, shortUrl), new CancellationToken());
    }

    public async Task<IEnumerable<UrlDto>> GetAllUrlsAsync()
    {
        var urls = await _mediator.Send(new GetAllUrlsQuery(), new CancellationToken());

        return urls;
    }

    public async Task<UrlDto> GetUrlByIdAsync(int id)
    {
        var urlDto = await _mediator.Send(new GetUrlByIdQuery(id), new CancellationToken());

        return urlDto;
    }

    public async Task DeleteUrlByIdAsync(int id)
    {
        await _mediator.Send(new DeleteUrlByIdCommand(id), new CancellationToken());
    }

    public async Task UpdateUrlAsync(int id, string shortUrl, DateTime dateCreated)
    {
        await _mediator.Send(new UpdateUrlCommand(id, shortUrl, dateCreated), new CancellationToken());
    }

    public async Task<string> JumpCounterAndReturnFullUrlAsync(string shortUrl)
    {
        var fullUrl = await _mediator.Send(new JumpCounterAndReturnFullUrlCommand(shortUrl), new CancellationToken());

        return fullUrl;
    }

    public async Task<bool> CheckingShortUrlInDatabase(int id, string shortUrl)
    {
        var result = await _mediator.Send(new CheckingShortUrlInDatabaseQuery(id, shortUrl), new CancellationToken());

        return result;
    }


    private string GenerateShortUrl(string salt)
    {
        Random random = new Random();
        string shortUrl = new string(Enumerable.Repeat(salt, 6)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
        return shortUrl + ".co";
    }
}
