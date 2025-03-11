using Portfolio.Services.AuthAPI.Models;

namespace Portfolio.Services.AuthAPI.Repositories;

public interface IUserRepository :
    IGetUserById,
    IGetUserByUsername,
    IGetUserByEmail,
    ICreateUser,
    IUpdateUser,
    ICheckUsernameExists,
    ICheckEmailExists,
    IAddRefreshToken,
    IGetRefreshToken,
    IRevokeRefreshToken
{
}
// Інтерфейс для отримання користувача за ідентифікатором
public interface IGetUserById
{
    Task<UserEntity?> GetByIdAsync(Guid id);
}

// Інтерфейс для отримання користувача за ім'ям користувача
public interface IGetUserByUsername
{
    Task<UserEntity?> GetByUsernameAsync(string username);
}

// Інтерфейс для отримання користувача за електронною поштою
public interface IGetUserByEmail
{
    Task<UserEntity?> GetByEmailAsync(string email);
}

// Інтерфейс для створення нового користувача
public interface ICreateUser
{
    Task<UserEntity> CreateAsync(UserEntity user);
}

// Інтерфейс для оновлення даних користувача
public interface IUpdateUser
{
    Task UpdateAsync(UserEntity user);
}

// Інтерфейс для перевірки існування користувача за ім'ям користувача
public interface ICheckUsernameExists
{
    Task<bool> UsernameExistsAsync(string username);
}

// Інтерфейс для перевірки існування користувача за електронною поштою
public interface ICheckEmailExists
{
    Task<bool> EmailExistsAsync(string email);
}

// Інтерфейс для додавання токена оновлення для користувача
public interface IAddRefreshToken
{
    Task<RefreshToken> AddRefreshTokenAsync(Guid userId, string token, DateTime expiresAt);
}

// Інтерфейс для отримання токена оновлення за його значенням
public interface IGetRefreshToken
{
    Task<RefreshToken?> GetRefreshTokenAsync(string token);
}

// Інтерфейс для відкликання токена оновлення
public interface IRevokeRefreshToken
{
    Task RevokeRefreshTokenAsync(string token);
}
