using Portfolio.Shared.Models;

namespace Portfolio.Client.Blazor.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task LogoutAsync();
    }
}
