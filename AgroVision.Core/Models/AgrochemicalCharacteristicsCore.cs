namespace AgroVision.Core.Models;

public class AgrochemicalCharacteristicsCore
{
    public Guid Id { get; set; }
    
    public string DistrictName { get; set; }
    
    public double MobilePhosphorus { get; set; }
    
    public double MobileKalium { get; set; }
    
    public double SaltExtract { get; set; }
    
    public double Humus { get; set; }
    
    public double GrainYield { get; set; }
    
    public double PotatoYield { get; set; }
    
    public double SunflowerYield { get; set; }
    
    public double OpenGroundVegetablesYield { get; set; }
    
    public double Srup { get; set; }
    
    public string SoilGradation { get; set; }

    public AgrochemicalCharacteristicsCore(
        Guid id,
        string districtName,
        double mobilePhosphorus,
        double mobileKalium,
        double saltExtract,
        double humus,
        double grainYield,
        double potatoYield,
        double sunflowerYield,
        double openGroundVegetablesYield,
        double srup,
        string soilGradation)
    {
        Id = id;
        DistrictName = districtName;
        MobilePhosphorus = mobilePhosphorus;
        MobileKalium = mobileKalium;
        SaltExtract = saltExtract;
        Humus = humus;
        GrainYield = grainYield;
        PotatoYield = potatoYield;
        SunflowerYield = sunflowerYield;
        OpenGroundVegetablesYield = openGroundVegetablesYield;
        Srup = srup;
        SoilGradation = soilGradation;
    }
}