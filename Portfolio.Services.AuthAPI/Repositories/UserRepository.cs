using Microsoft.EntityFrameworkCore;
using Portfolio.Services.AuthAPI.Data;
using Portfolio.Services.AuthAPI.Models;

namespace Portfolio.Services.AuthAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthDbContext _dbContext;

    public UserRepository(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Отримати користувача за ідентифікатором
    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    // Отримати користувача за ім'ям користувача
    public async Task<UserEntity?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
    }

    // Отримати користувача за електронною поштою
    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    // Створити нового користувача
    public async Task<UserEntity> CreateAsync(UserEntity user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    // Оновити дані користувача
    public async Task UpdateAsync(UserEntity user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    // Перевірити, чи існує користувач з таким ім'ям користувача
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.Username.ToLower() == username.ToLower());
    }

    // Перевірити, чи існує користувач з такою електронною поштою
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }

    // Додати токен оновлення для користувача
    public async Task<RefreshToken> AddRefreshTokenAsync(Guid userId, string token, DateTime expiresAt)
    {
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = token,
            ExpiresAt = expiresAt,
            CreatedAt = DateTime.UtcNow
        };

        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();

        return refreshToken;
    }

    // Отримати токен оновлення за значенням токена
    public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
    {
        return await _dbContext.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == token);
    }

    // Відкликати токен оновлення
    public async Task RevokeRefreshTokenAsync(string token)
    {
        var refreshToken = await _dbContext.RefreshTokens
            .FirstOrDefaultAsync(r => r.Token == token);

        if (refreshToken != null)
        {
            refreshToken.RevokedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }
    }
}
