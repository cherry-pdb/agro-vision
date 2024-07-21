using AgroVision.Core.Models;
using AgroVision.Core.Repositories;
using AgroVision.Database.Context;
using AgroVision.Database.Repositories.Converters;
using Microsoft.EntityFrameworkCore;

namespace AgroVision.Database.Repositories;

public class AgrochemicalCharacteristicsRepository : IAgrochemicalCharacteristicsRepository
{
    private readonly AgroVisionContext _dbContext;

    public AgrochemicalCharacteristicsRepository(AgroVisionContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAgrochemicalCharacteristicAsync(AgrochemicalCharacteristicsCore agrochemicalCharacteristicsCore)
    {
        await _dbContext.AgrochemicalСharacteristics.AddAsync(AgrochemicalCharacteristicConverter.ConvertToDb(agrochemicalCharacteristicsCore)!);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<AgrochemicalCharacteristicsCore>> GetAllAgrochemicalCharacteristicsAsync()
    {
        var agrochemicalCharacteristicsDb = await _dbContext.AgrochemicalСharacteristics.ToListAsync();

        return agrochemicalCharacteristicsDb.ConvertAll(input =>
            AgrochemicalCharacteristicConverter.ConvertToCore(input)!);
    }

    public async Task<AgrochemicalCharacteristicsCore> GetAgrochemicalCharacteristicByIdAsync(Guid id)
    {
        var agrochemicalCharacteristicsDb = await _dbContext.AgrochemicalСharacteristics
            .AsNoTracking()
            .FirstOrDefaultAsync(ac => ac.Id == id);

        if (agrochemicalCharacteristicsDb is null)
            throw new InvalidOperationException($"Agrochemical characteristic with id: {id} not found.");

        return AgrochemicalCharacteristicConverter.ConvertToCore(agrochemicalCharacteristicsDb)!;
    }

    public async Task<AgrochemicalCharacteristicsCore> GetAgrochemicalCharacteristicByDistinctNameAsync(string distinctName)
    {
        var agrochemicalCharacteristicsDb = await _dbContext.AgrochemicalСharacteristics
            .AsNoTracking()
            .FirstOrDefaultAsync(ac => ac.DistrictName == distinctName);

        if (agrochemicalCharacteristicsDb is null)
            throw new InvalidOperationException($"Agrochemical characteristic with distinct name: {distinctName} not found.");

        return AgrochemicalCharacteristicConverter.ConvertToCore(agrochemicalCharacteristicsDb)!;
    }

    public async Task UpdateAgrochemicalCharacteristicAsync(AgrochemicalCharacteristicsCore agrochemicalCharacteristicsCore)
    {
        var agrochemicalCharacteristicsToUpdate = await _dbContext.AgrochemicalСharacteristics.FindAsync(agrochemicalCharacteristicsCore.Id);

        if (agrochemicalCharacteristicsToUpdate is null)
            throw new InvalidOperationException($"Agrochemical characteristic with id: {agrochemicalCharacteristicsCore.Id} not found.");

        agrochemicalCharacteristicsToUpdate.DistrictName = agrochemicalCharacteristicsCore.DistrictName;
        agrochemicalCharacteristicsToUpdate.MobilePhosphorus = agrochemicalCharacteristicsCore.MobilePhosphorus;
        agrochemicalCharacteristicsToUpdate.MobileKalium = agrochemicalCharacteristicsCore.MobileKalium;
        agrochemicalCharacteristicsToUpdate.SaltExtract = agrochemicalCharacteristicsCore.SaltExtract;
        agrochemicalCharacteristicsToUpdate.Humus = agrochemicalCharacteristicsCore.Humus;
        agrochemicalCharacteristicsToUpdate.GrainYield = agrochemicalCharacteristicsCore.GrainYield;
        agrochemicalCharacteristicsToUpdate.PotatoYield = agrochemicalCharacteristicsCore.PotatoYield;
        agrochemicalCharacteristicsToUpdate.SunflowerYield = agrochemicalCharacteristicsCore.SunflowerYield;
        agrochemicalCharacteristicsToUpdate.OpenGroundVegetablesYield = agrochemicalCharacteristicsCore.OpenGroundVegetablesYield;
        agrochemicalCharacteristicsToUpdate.Srup = agrochemicalCharacteristicsCore.Srup;
        agrochemicalCharacteristicsToUpdate.SoilGradation = agrochemicalCharacteristicsCore.SoilGradation;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAgrochemicalCharacteristicByIdAsync(Guid id)
    {
        var agrochemicalCharacteristicsToRemove = await _dbContext.AgrochemicalСharacteristics.FindAsync(id);
        
        if (agrochemicalCharacteristicsToRemove is null)
            throw new InvalidOperationException($"Agrochemical characteristic with id: {id} not found.");

        _dbContext.AgrochemicalСharacteristics.Remove(agrochemicalCharacteristicsToRemove);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAgrochemicalCharacteristicByDistinctNameAsync(string distinctName)
    {
        var agrochemicalCharacteristicsToRemove = await _dbContext.AgrochemicalСharacteristics.FindAsync(distinctName);
        
        if (agrochemicalCharacteristicsToRemove is null)
            throw new InvalidOperationException($"Agrochemical characteristic with distinct name: {distinctName} not found.");

        _dbContext.AgrochemicalСharacteristics.Remove(agrochemicalCharacteristicsToRemove);
        await _dbContext.SaveChangesAsync();
    }

    public Task<bool> ExistsAgrochemicalCharacteristicByIdAsync(Guid id)
    {
        return _dbContext.AgrochemicalСharacteristics.AsNoTracking().AnyAsync(ac => ac.Id == id);
    }

    public Task<bool> ExistsAgrochemicalCharacteristicByDistinctNameAsync(string distinctName)
    {
        return _dbContext.AgrochemicalСharacteristics.AsNoTracking().AnyAsync(ac => ac.DistrictName == distinctName);
    }
}