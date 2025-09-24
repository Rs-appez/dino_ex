namespace Dino.API.Entities;

public class Dino
{
    public string? Espece { get; set; }
    public double LengthMeters { get; set; }
    public double WeightKg { get; set; }
}

public class DinoToUpdate
{
    public int Id { get; set; }
    public string? Espece { get; set; }
    public double? LengthMeters { get; set; }
    public double? WeightKg { get; set; }
}

