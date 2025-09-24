using AEntities = Dino.API.Entities;
using BEntities = Dino.BLL.Entities;

namespace Dino.API.Mappers;

public static class Mapper
{
    public static AEntities.Dino ToDto(this BEntities.Dino dino) =>
        new AEntities.Dino
        {
            Espece = dino.Espece,
            LengthMeters = dino.LengthMeters,
            WeightKg = dino.WeightKg
        };

    public static BEntities.Dino ToBLL(this AEntities.Dino dino) =>
        new BEntities.Dino(
            dino.Espece,
            dino.LengthMeters,
            dino.WeightKg
        );

    public static BEntities.Dino UpdateBLL(this BEntities.Dino existingDino, AEntities.DinoToUpdate dino)
        => new BEntities.Dino(
            dino.Id,
            dino.Espece ?? existingDino.Espece,
            dino.LengthMeters ?? existingDino.LengthMeters,
            dino.WeightKg ?? existingDino.WeightKg
        );

}
