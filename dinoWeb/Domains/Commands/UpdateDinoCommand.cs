using System.Text.Json.Serialization;
using Dino.Cqs.Commands;
using Dino.Web.Domain.Entities;

namespace Dino.Web.Domain.Commands;
public class UpdateDinoCommand : ICommandDefinition
{
    [JsonPropertyName("id")]
    public int Id { get; }
    [JsonPropertyName("weightKg")]
    public double Poids { get; }
    [JsonPropertyName("lengthMeters")]
    public double Taille { get; }  

    public UpdateDinoCommand(int id, double poids, double taille)
    {
        Id = id;
        Poids = poids;
        Taille = taille;
    }

    public UpdateDinoCommand(Dinosus dino)
    {
        Id = dino.Id;
        Poids = (double)dino.Poids;
        Taille = (double)dino.Taille;
    }
}
