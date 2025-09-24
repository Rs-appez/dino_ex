using BEntities = Dino.BLL.Entities;
using DEntities = Dino.DAL.Entities;

namespace Dino.BLL.Mappers;

internal static class Mapper
{
    public static BEntities.Dino ToBll(this DEntities.Dino dino) =>
        new BEntities.Dino(
            dino.Id,
            dino.Espece,
            dino.LengthMeters,
            dino.WeightKg
        )
;

    public static DEntities.Dino ToDal(this BEntities.Dino dino) =>
        new DEntities.Dino
        {
            Id = dino.Id,
            Espece = dino.Espece,
            LengthMeters = dino.LengthMeters,
            WeightKg = dino.WeightKg
        };

}
