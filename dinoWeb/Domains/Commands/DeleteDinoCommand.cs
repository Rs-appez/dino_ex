using Dino.Cqs.Commands;

namespace Dino.Web.Domain.Commands;
public class DeleteDinoCommand : ICommandDefinition
{
    public int Id { get; }

    public DeleteDinoCommand(int id)
    {
        Id = id;
    }
}
