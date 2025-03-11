using Portfolio.Shared.Models;

namespace Portfolio.Services.AuthAPI.Services
{
    public interface IAuthService
    {
        Task<(bool success, string? errorMessage)> RegisterAsync(RegisterRequest request);
        Task<(bool success, string? token, string? refreshToken, DateTime? expiresAt, string? errorMessage)> LoginAsync(LoginRequest request);
        Task<(bool success, string? errorMessage)> RefreshTokenAsync(string token);
    }
}
