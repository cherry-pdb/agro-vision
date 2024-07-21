using AgroVision.Core.Models;

namespace AgroVision.Core.Repositories;

public interface IAgrochemicalCharacteristicsRepository
{
    Task AddAgrochemicalCharacteristicAsync(AgrochemicalCharacteristicsCore agrochemicalCharacteristicsCore);

    Task<List<AgrochemicalCharacteristicsCore>> GetAllAgrochemicalCharacteristicsAsync();
    
    Task<AgrochemicalCharacteristicsCore> GetAgrochemicalCharacteristicByIdAsync(Guid id);

    Task<AgrochemicalCharacteristicsCore> GetAgrochemicalCharacteristicByDistinctNameAsync(string distinctName);

    Task UpdateAgrochemicalCharacteristicAsync(AgrochemicalCharacteristicsCore agrochemicalCharacteristicsCore);

    Task RemoveAgrochemicalCharacteristicByIdAsync(Guid id);
    
    Task RemoveAgrochemicalCharacteristicByDistinctNameAsync(string distinctName);

    Task<bool> ExistsAgrochemicalCharacteristicByIdAsync(Guid id);

    Task<bool> ExistsAgrochemicalCharacteristicByDistinctNameAsync(string distinctName);
}