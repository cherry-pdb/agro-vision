using AgroVision.Core.Repositories;
using AgroVision.Dto.Converters;
using AgroVision.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgroVision.Server.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserRepository userRepository, ILogger<UsersController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
    {
        try
        {
            var userCore = await _userRepository.FindUserByIdAsync(id);

            if (userCore is null)
                return NotFound();

            return Ok(UserConverter.ConvertToDto(userCore));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetUserByIdAsync));
            
            return StatusCode(500);
        }
    }
    
    [HttpGet("{login}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 404, description: "Неверный идентификатор.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetUserByLoginAsync([FromRoute] string login)
    {
        try
        {
            var userCore = await _userRepository.FindUserByLoginAsync(login);

            if (userCore is null)
                return NotFound();

            return Ok(UserConverter.ConvertToDto(userCore));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetUserByLoginAsync));
            
            return StatusCode(500);
        }
    }
    
    [HttpGet]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        try
        {
            var usersCore = await _userRepository.GetAllUsersAsync();
            
            return Ok(usersCore.ConvertAll(UserConverter.ConvertToDto));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(GetAllUsersAsync));
            
            return StatusCode(500);
        }
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(statusCode: 200, description: "Действие успешно.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> PutUserAsync([FromRoute] Guid id, [FromBody] UserDto userDto)
    {
        try
        {
            if (await _userRepository.ExistsUserByIdAsync(id))
            {
                await _userRepository.UpdateUserAsync(UserConverter.ConvertToCore(userDto)!);
            }
            else
            {
                await _userRepository.AddUserAsync(UserConverter.ConvertToCore(userDto)!);
            }
            
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in method: {MethodName}.", nameof(PutUserAsync));
            
            return StatusCode(500);
        }
    }
}