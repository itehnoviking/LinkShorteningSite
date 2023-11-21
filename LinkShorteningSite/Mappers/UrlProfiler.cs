using AutoMapper;
using LinkShorteningSite.Core.DTOs;
using LinkShorteningSite.CQRS.Models.Commands.UrlCommands;
using LinkShorteningSite.Data.Entities;
using LinkShorteningSite.Models;

namespace LinkShorteningSite.Mappers;

public class UrlProfiler : Profile
{
    public UrlProfiler()
    {
        CreateMap<UrlCreateViewModel, UrlDto>().ReverseMap();
        CreateMap<Url, UrlDto>().ReverseMap();
        CreateMap<CreateUrlCommand, Url>().ReverseMap();
        CreateMap<UrlViewModel, UrlDto>().ReverseMap();
        CreateMap<UrlEditViewModel, UrlDto>().ReverseMap();
    }
}