using Microsoft.Data.SqlClient;
using Entities = Dino.DAL.Entities;
namespace Dino.DAL.Mappers;

internal static class Mapper
{
    public static Entities.Dino ToDino(this SqlDataReader reader)
    {
        return new Entities.Dino
        {
            Id = (int)reader["Id"],
            Espece = (string)reader["espece"],
            LengthMeters = Convert.ToDouble(reader["length_meters"]),
            WeightKg = Convert.ToDouble(reader["weight_kg"])
        };
    }

}
