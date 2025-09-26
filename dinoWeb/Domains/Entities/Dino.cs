namespace Dino.Web.Domain.Entities
{
    public class Dinosus
    {
        public int Id { get; }
        public string Espece { get; set; }
        public int Poids { get; set; }
        public int Taille { get; set; }

        internal Dinosus(int id, string espece, int poids, int taille) 
        {
            Id = id;
            Espece = espece;
            Poids = poids;
            Taille = taille;
        }

        public Dinosus(){}
    }
}
