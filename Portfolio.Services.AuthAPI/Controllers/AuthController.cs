// Portfolio.Services.AuthAPI/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using Portfolio.Services.AuthAPI.Services;
using Portfolio.Shared.Models;

namespace Portfolio.Services.AuthAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Метод для реєстрації нового користувача
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var (success, errorMessage) = await _authService.RegisterAsync(request);
        if (!success)
            return BadRequest(new { error = errorMessage });
        return Ok(new { message = "User registered successfully." });
    }

    // Метод для входу користувача
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var (success, token, refreshToken, expiresAt, errorMessage) = await _authService.LoginAsync(request);
        if (!success)
            return Unauthorized(new { error = errorMessage });
        return Ok(new { token, refreshToken, expiresAt });
    }

    // Метод для оновлення токена
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] string token)
    {
        var (success, errorMessage) = await _authService.RefreshTokenAsync(token);
        if (!success)
            return Unauthorized(new { error = errorMessage });
        return Ok(new { message = "Token refreshed successfully." });
    }
}
