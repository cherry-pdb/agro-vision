using AgroVision.Core.Models;
using AgroVision.Dto.Models;

namespace AgroVision.Dto.Converters;

public static class AgrochemicalCharacteristicConverter
{
    public static AgrochemicalCharacteristicsCore? ConvertToCore(AgrochemicalСharacteristicsDto? agrochemicalСharacteristicsDto)
        => agrochemicalСharacteristicsDto is null
            ? null
            : new AgrochemicalCharacteristicsCore(
                agrochemicalСharacteristicsDto.Id,
                agrochemicalСharacteristicsDto.DistrictName,
                agrochemicalСharacteristicsDto.MobilePhosphorus,
                agrochemicalСharacteristicsDto.MobileKalium,
                agrochemicalСharacteristicsDto.SaltExtract,
                agrochemicalСharacteristicsDto.Humus,
                agrochemicalСharacteristicsDto.GrainYield,
                agrochemicalСharacteristicsDto.PotatoYield,
                agrochemicalСharacteristicsDto.SunflowerYield,
                agrochemicalСharacteristicsDto.OpenGroundVegetablesYield,
                agrochemicalСharacteristicsDto.Srup,
                agrochemicalСharacteristicsDto.SoilGradation);
    
    public static AgrochemicalСharacteristicsDto? ConvertToDto(AgrochemicalCharacteristicsCore? agrochemicalСharacteristicsCore)
        => agrochemicalСharacteristicsCore is null
            ? null
            : new AgrochemicalСharacteristicsDto(
                agrochemicalСharacteristicsCore.Id,
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