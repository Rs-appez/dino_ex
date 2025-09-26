using Dino.Cqs.Commands;

namespace Dino.Web.Domain.Commands;
public class UpdateDinoCommand : ICommandDefinition
{
    public int Id { get; }
    public int Poids { get; }
    public int Taille { get; }  

    public UpdateDinoCommand(int id, int poids, int taille)
    {
        Id = id;
        Poids = poids;
        Taille = taille;
    }
}
