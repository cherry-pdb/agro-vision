using AgroVision.Core.Repositories;
using AgroVision.Dto.Converters;
using AgroVision.Dto.Enums;
using AgroVision.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgroVision.Server.Controllers;

[ApiController]
[Route("/api/agrochemical-characteristic")]
public class AgrochemicalCharacteristicsController : ControllerBase
{
    private readonly IAgrochemicalCharacteristicsRepository _agrochemicalCharacteristicsRepository;
    private readonly ILogger<AgrochemicalCharacteristicsController> _logger;

    public AgrochemicalCharacteristicsController(
        ILogger<AgrochemicalCharacteristicsController> logger, 
        IAgrochemicalCharacteristicsRepository agrochemicalCharacteristicsRepository)
    {
        _logger = logger;
        _agrochemicalCharacteristicsRepository = agrochemicalCharacteristicsRepository;
    }

    [HttpGet("{sortedNumber:int}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetAgrochemicalCharacteristicsAsync(int sortedNumber)
    {
        try
        {
            var agrochemicalCharacteristicsCore =
                await _agrochemicalCharacteristicsRepository.GetAllAgrochemicalCharacteristicsAsync();
            var agrochemicalCharacteristicsDto =
                agrochemicalCharacteristicsCore.ConvertAll(AgrochemicalCharacteristicConverter.ConvertToDto);

            List<AgrochemicalСharacteristicsDto> sorted = sortedNumber switch
            {
                (int)SortedType.Humus 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.DistrictName).ToList(),
                (int)SortedType.GrainYield 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.GrainYield).ToList(),
                (int)SortedType.PotatoYield 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.PotatoYield).ToList(),
                (int)SortedType.SunflowerYield 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.SunflowerYield).ToList(),
                (int)SortedType.OpenGroundVegetablesYield 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.OpenGroundVegetablesYield).ToList(),
                (int)SortedType.Srup 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.Srup).ToList(),
                (int)SortedType.SoilGradation 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.SoilGradation).ToList(),
                _ 
                    => agrochemicalCharacteristicsDto.OrderBy(ac => ac.DistrictName).ToList()
            };

            return Ok(sorted);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetAgrochemicalCharacteristicsAsync));

            return StatusCode(500);
        }
    }
    
    [HttpGet("{id:guid}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetAgrochemicalCharacteristicByIdAsync([FromRoute] Guid id)
    {
        try
        {
            var agrochemicalCharacteristicCore = 
                await _agrochemicalCharacteristicsRepository.GetAgrochemicalCharacteristicByIdAsync(id);
            

            return Ok(AgrochemicalCharacteristicConverter.ConvertToDto(agrochemicalCharacteristicCore));
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e, e.Message);
            
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetAgrochemicalCharacteristicByIdAsync));

            return StatusCode(500);
        }
    }
    
    [HttpGet("{distinctName}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetAgrochemicalCharacteristicByDistinctNameAsync([FromRoute] string distinctName)
    {
        try
        {
            var agrochemicalCharacteristicCore = 
                await _agrochemicalCharacteristicsRepository.GetAgrochemicalCharacteristicByDistinctNameAsync(distinctName);
            

            return Ok(AgrochemicalCharacteristicConverter.ConvertToDto(agrochemicalCharacteristicCore));
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e, e.Message);
            
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetAgrochemicalCharacteristicByDistinctNameAsync));

            return StatusCode(500);
        }
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> PutAgrochemicalCharacteristicByIdAsync(
        [FromRoute] Guid id,
        [FromBody] AgrochemicalСharacteristicsDto agrochemicalСharacteristicsDto)
    {
        try
        {
            if (await _agrochemicalCharacteristicsRepository.ExistsAgrochemicalCharacteristicByIdAsync(id))
            {
                await _agrochemicalCharacteristicsRepository.UpdateAgrochemicalCharacteristicAsync(
                    AgrochemicalCharacteristicConverter.ConvertToCore(agrochemicalСharacteristicsDto)!);
            }
            else
            {
                await _agrochemicalCharacteristicsRepository.AddAgrochemicalCharacteristicAsync(
                    AgrochemicalCharacteristicConverter.ConvertToCore(agrochemicalСharacteristicsDto)!);
            }

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(PutAgrochemicalCharacteristicByIdAsync));

            return StatusCode(500);
        }
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> DeleteAgrochemicalCharacteristicByIdAsync([FromRoute] Guid id)
    {
        try
        {
            await _agrochemicalCharacteristicsRepository.RemoveAgrochemicalCharacteristicByIdAsync(id);
            

            return Ok();
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e, e.Message);
            
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(DeleteAgrochemicalCharacteristicByIdAsync));

            return StatusCode(500);
        }
    }
    
    [HttpDelete("{distinctName}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> DeleteAgrochemicalCharacteristicByDistinctNameAsync([FromRoute] string distinctName)
    {
        try
        {
            await _agrochemicalCharacteristicsRepository.RemoveAgrochemicalCharacteristicByDistinctNameAsync(distinctName);
            

            return Ok();
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e, e.Message);
            
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(DeleteAgrochemicalCharacteristicByDistinctNameAsync));

            return StatusCode(500);
        }
    }
}