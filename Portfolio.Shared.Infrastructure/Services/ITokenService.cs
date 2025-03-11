using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Infrastructure.Services
{
    /// <summary>
    /// Інтерфейс для сервісу токенів, який включає генерацію JWT токенів, генерацію токенів оновлення та валідацію токенів.
    /// </summary>
    public interface ITokenService : IJwtTokenService, IRefreshTokenService, ITokenValidationService
    {
    }


    /// <summary>
    /// Інтерфейс для сервісу генерації JWT токенів.
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Генерує JWT токен для вказаного користувача.
        /// </summary>
        /// <param name="user">Користувач, для якого генерується токен.</param>
        /// <returns>JWT токен у вигляді рядка.</returns>
        string GenerateJwtToken(User user);
    }

    /// <summary>
    /// Інтерфейс для сервісу генерації токенів оновлення.
    /// </summary>
    public interface IRefreshTokenService
    {
        /// <summary>
        /// Генерує токен оновлення.
        /// </summary>
        /// <returns>Токен оновлення у вигляді рядка.</returns>
        string GenerateRefreshToken();
    }

    /// <summary>
    /// Інтерфейс для сервісу валідації токенів.
    /// </summary>
    public interface ITokenValidationService
    {
        /// <summary>
        /// Валідовує вказаний токен та отримує ідентифікатор користувача, якщо токен дійсний.
        /// </summary>
        /// <param name="token">Токен для валідації.</param>
        /// <param name="userId">Ідентифікатор користувача, отриманий з токену, якщо він дійсний.</param>
        /// <returns>True, якщо токен дійсний; інакше, false.</returns>
        bool ValidateToken(string token, out Guid userId);
    }
}
