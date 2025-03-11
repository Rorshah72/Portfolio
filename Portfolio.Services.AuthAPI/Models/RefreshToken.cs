namespace Portfolio.Services.AuthAPI.Models
{
    public class RefreshToken
    {
        // Унікальний ідентифікатор токена
        public Guid Id { get; set; }

        // Ідентифікатор користувача, якому належить токен
        public Guid UserId { get; set; }

        // Сам токен
        public string Token { get; set; } = null!;

        // Дата та час закінчення дії токена
        public DateTime ExpiresAt { get; set; }

        // Дата та час створення токена
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Дата та час відкликання токена (якщо є)
        public DateTime? RevokedAt { get; set; }

        // Перевірка, чи закінчився термін дії токена
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        // Перевірка, чи активний токен
        public bool IsActive => RevokedAt == null && !IsExpired;

        // Користувач, якому належить токен
        public UserEntity User { get; set; } = null!;
    }
}
