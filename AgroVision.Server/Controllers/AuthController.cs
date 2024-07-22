using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AgroVision.Core.Models;
using AgroVision.Core.Repositories;
using AgroVision.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace AgroVision.Server.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;

    public AuthController(
        IUserRepository userRepository,
        IConfiguration configuration,
        ILogger<AuthController> logger)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost("login")]
    [SwaggerResponse(statusCode: 200, description: "Авторизация успешна.")]
    [SwaggerResponse(statusCode: 404, description: "Авторизация не удалась. Неправильный логин или пароль.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> Login([FromBody] LoginCredentials loginCredentials)
    {
        try
        {
            var authData = await _userRepository.FindUserByLoginAsync(
                loginCredentials.Login);
            
            if (authData is null)
            {
                _logger.LogWarning("User with login {login} was not found.", loginCredentials.Login);

                return NotFound();
            }

            if (!VerifyPassword(loginCredentials.Password, authData.Password))
            {
                _logger.LogWarning("User with login {login} entered invalid password.", loginCredentials.Login);
                
                return Unauthorized();
            }
            
            var token = GenerateJwtToken(loginCredentials.Login);
            
            _logger.LogInformation("User logged in: {User}", authData);

            return Ok(new { UserId = authData.Id, UserLogin = authData.Login, Token = token });
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Error in method {MethodName}.", nameof(Login));

            return StatusCode(500);
        }
    }

    [HttpPost("register")]
    [SwaggerResponse(statusCode: 200, description: "Авторизация успешна.")]
    [SwaggerResponse(statusCode: 400, description: "Регистрация не удалась. Пользователь с таким логином уже существует.")]
    [SwaggerResponse(statusCode: 500, description: "Ошибка на стороне сервера.")]
    public async Task<IActionResult> Register(LoginCredentials loginCredentials)
    {
        try
        {
            var user = await _userRepository.FindUserByLoginAsync(loginCredentials.Login);

            if (user is not null)
                return BadRequest("User already exists.");

            await _userRepository.AddUserAsync(
                new UserCore(
                    Guid.NewGuid(),
                    loginCredentials.Login,
                    HashPassword(loginCredentials.Password)));

            return Ok($"User {loginCredentials.Login} registered successfully.");
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Error in method {MethodName}.", nameof(Login));

            return StatusCode(500);
        }
    }

    private string GenerateJwtToken(string login)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, login),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private bool VerifyPassword(string enteredPassword, string hashedPassword)
        => hashedPassword.Equals(HashPassword(enteredPassword), StringComparison.OrdinalIgnoreCase);

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var stringBuilder = new StringBuilder();

        foreach (var @byte in bytes)
        {
            stringBuilder.Append(@byte.ToString("x2"));
        }

        return stringBuilder.ToString();
    }
}