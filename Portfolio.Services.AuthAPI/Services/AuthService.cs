using Portfolio.Shared.Models;
using Portfolio.Services.AuthAPI.Models;
using Portfolio.Services.AuthAPI.Repositories;
using Portfolio.Shared.Infrastructure.Services;


namespace Portfolio.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<(bool success, string? errorMessage)> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.UsernameExistsAsync(request.Username))
                return (false, "Username already exists.");

            if (await _userRepository.EmailExistsAsync(request.Email))
                return (false, "Email already exists.");

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = _passwordHasher.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.CreateAsync(user);
            return (true, null);
        }

        public async Task<(bool success, string? token, string? refreshToken, DateTime? expiresAt, string? errorMessage)> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null || !_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
                return (false, null, null, null, "Invalid username or password.");

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            await _userRepository.AddRefreshTokenAsync(user.Id, refreshToken, DateTime.UtcNow.AddDays(7));

            return (true, token, refreshToken, DateTime.UtcNow.AddHours(1), null);
        }

        public async Task<(bool success, string? errorMessage)> RefreshTokenAsync(string token)
        {
            var refreshToken = await _userRepository.GetRefreshTokenAsync(token);
            if (refreshToken == null || !refreshToken.IsActive)
                return (false, "Invalid refresh token.");

            var user = await _userRepository.GetByIdAsync(refreshToken.UserId);
            if (user == null)
                return (false, "User not found.");

            // Generate new token and refresh token
            var newToken = _tokenService.GenerateJwtToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            await _userRepository.AddRefreshTokenAsync(user.Id, newRefreshToken, DateTime.UtcNow.AddDays(7));

            return (true, null);
        }
    }
}
