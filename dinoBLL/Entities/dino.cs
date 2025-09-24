namespace Dino.BLL.Entities;

public class Dino
{
    public int Id { get; set; }
    public string? Espece { get; set; }
    public double LengthMeters { get; set; }
    public double WeightKg { get; set; }

    public Dino(int id, string? espece, double lengthMeters, double weightKg)
    {
        Id = id;
        Espece = espece;
        LengthMeters = lengthMeters;
        WeightKg = weightKg;
    }

    public Dino(string? espece, double lengthMeters, double weightKg)
    {
        Espece = espece;
        LengthMeters = lengthMeters;
        WeightKg = weightKg;
    }

    public override string ToString()
    {
        return $"Dino [Id={Id}, Espece={Espece}, LengthMeters={LengthMeters}, WeightKg={WeightKg}]";
    }

}
