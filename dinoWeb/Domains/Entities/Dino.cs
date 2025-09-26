using System.Text.Json.Serialization;

namespace Dino.Web.Domain.Entities
{
    public class Dinosus
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("espece")]
        public string Espece { get; set; }
        [JsonPropertyName("weightKg")]
        public double Poids { get; set; }
        [JsonPropertyName("lengthMeters")]
        public double Taille { get; set; }

        internal Dinosus(int id, string espece, double poids, double taille) 
        {
            Id = id;
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }

        public Dinosus(){}

        public override string ToString()
        {
            return $"Dinosus(Id={Id}, Espece={Espece}, Poids={Poids}, Taille={Taille})";
        }
    }
}
