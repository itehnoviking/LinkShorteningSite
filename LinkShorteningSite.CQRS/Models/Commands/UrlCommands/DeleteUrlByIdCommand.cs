using MediatR;

namespace LinkShorteningSite.CQRS.Models.Commands.UrlCommands;

public class DeleteUrlByIdCommand : IRequest<bool>
{
    public DeleteUrlByIdCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}