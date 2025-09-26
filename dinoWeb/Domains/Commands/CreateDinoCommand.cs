using Dino.Cqs.Commands;

namespace Dino.Web.Domain.Commands;
public class CreateDinoCommand : ICommandDefinition
{
    public string Espece { get; }
    public int Poids { get; }
    public int Taille { get; }

    public CreateDinoCommand(string espece, int poids, int taille)
    {
        Espece = espece;
        Poids = poids;
        Taille = taille;
    }
}
