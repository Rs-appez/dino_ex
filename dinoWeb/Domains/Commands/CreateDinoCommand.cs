using System.Text.Json.Serialization;
using Dino.Cqs.Commands;
using Dino.Web.Domain.Entities;

namespace Dino.Web.Domain.Commands;
public class CreateDinoCommand : ICommandDefinition
{
    public string Espece { get; }
    [JsonPropertyName("weightKg")]
    public double Poids { get; }
    [JsonPropertyName("lengthMeters")]
    public double Taille { get; }

    public CreateDinoCommand(string espece, double poids, double taille)
    {
        Espece = espece;
        Poids = poids;
        Taille = taille;
    }
    public CreateDinoCommand(Dinosus dino)
    {
        Espece = dino.Espece;
        Poids = dino.Poids;
        Taille = dino.Taille;
    }
    
}
