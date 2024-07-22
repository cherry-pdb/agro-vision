using AgroVision.Core.Models;
using AgroVision.Database.Models;

namespace AgroVision.Database.Repositories.Converters;

public static class AgrochemicalCharacteristicConverter
{
    public static AgrochemicalCharacteristicsCore? ConvertToCore(AgrochemicalСharacteristicsDb? agrochemicalСharacteristicsDb)
        => agrochemicalСharacteristicsDb is null
            ? null
            : new AgrochemicalCharacteristicsCore(
                agrochemicalСharacteristicsDb.Id,
                agrochemicalСharacteristicsDb.DistrictId,
                agrochemicalСharacteristicsDb.DistrictName,
                agrochemicalСharacteristicsDb.MobilePhosphorus,
                agrochemicalСharacteristicsDb.MobileKalium,
                agrochemicalСharacteristicsDb.SaltExtract,
                agrochemicalСharacteristicsDb.Humus,
                agrochemicalСharacteristicsDb.GrainYield,
                agrochemicalСharacteristicsDb.PotatoYield,
                agrochemicalСharacteristicsDb.SunflowerYield,
                agrochemicalСharacteristicsDb.OpenGroundVegetablesYield,
                agrochemicalСharacteristicsDb.Srup,
                agrochemicalСharacteristicsDb.SoilGradation);
    
    public static AgrochemicalСharacteristicsDb? ConvertToDb(AgrochemicalCharacteristicsCore? agrochemicalСharacteristicsCore)
        => agrochemicalСharacteristicsCore is null
            ? null
            : new AgrochemicalСharacteristicsDb(
                agrochemicalСharacteristicsCore.Id,
                agrochemicalСharacteristicsCore.DistrictId,
                agrochemicalСharacteristicsCore.DistrictName,
                agrochemicalСharacteristicsCore.MobilePhosphorus,
                agrochemicalСharacteristicsCore.MobileKalium,
                agrochemicalСharacteristicsCore.SaltExtract,
                agrochemicalСharacteristicsCore.Humus,
                agrochemicalСharacteristicsCore.GrainYield,
                agrochemicalСharacteristicsCore.PotatoYield,
                agrochemicalСharacteristicsCore.SunflowerYield,
                agrochemicalСharacteristicsCore.OpenGroundVegetablesYield,
                agrochemicalСharacteristicsCore.Srup,
                agrochemicalСharacteristicsCore.SoilGradation);
}