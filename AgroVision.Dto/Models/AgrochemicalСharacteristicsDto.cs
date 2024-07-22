using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AgroVision.Dto.Models;

public class AgrochemicalСharacteristicsDto
{
    [Required]
    [DataMember(Name = "id")]
    public Guid Id { get; set; }
    
    [Required]
    [DataMember(Name = "districtId")]
    public int DistrictId { get; set; }
    
    [Required]
    [DataMember(Name = "districtName")]
    public string DistrictName { get; set; }
    
    [Required]
    [DataMember(Name = "mobilePhosphorus")]
    public double MobilePhosphorus { get; set; }
    
    [Required]
    [DataMember(Name = "mobileKalium")]
    public double MobileKalium { get; set; }
    
    [Required]
    [DataMember(Name = "saltExtract")]
    public double SaltExtract { get; set; }
    
    [Required]
    [DataMember(Name = "humus")]
    public double Humus { get; set; }
    
    [Required]
    [DataMember(Name = "grainYield")]
    public double GrainYield { get; set; }
    
    [Required]
    [DataMember(Name = "potatoYield")]
    public double PotatoYield { get; set; }

    [Required]
    [DataMember(Name = "sunflowerYield")]
    public double SunflowerYield { get; set; }
    
    [Required]
    [DataMember(Name = "openGroundVegetablesYield")]
    public double OpenGroundVegetablesYield { get; set; }
    
    [Required]
    [DataMember(Name = "srup")]
    public double Srup { get; set; }
    
    [Required]
    [DataMember(Name = "soilGradation")]
    public string SoilGradation { get; set; }

    public AgrochemicalСharacteristicsDto(
        Guid id,
        int districtId,
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
        DistrictId = districtId;
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
