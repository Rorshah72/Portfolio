namespace Portfolio.Services.AuthAPI.Models
{
    public class UserEntity
    {
        // Унікальний ідентифікатор користувача
        public Guid Id { get; set; }

        // Ім'я користувача
        public string Username { get; set; } = null!;

        // Електронна пошта користувача
        public string Email { get; set; } = null!;

        // Хеш пароля користувача
        public string PasswordHash { get; set; } = null!;

        // Ім'я користувача
        public string FirstName { get; set; } = null!;

        // Прізвище користувача
        public string LastName { get; set; } = null!;

        // URL фотографії користувача
        public string? PhotoUrl { get; set; }

        // Посилання на Telegram користувача
        public string? TelegramLink { get; set; }

        // Посилання на GitHub користувача
        public string? GitHubLink { get; set; }

        // Посилання на LinkedIn користувача
        public string? LinkedInLink { get; set; }

        // номер телефону користувача
        public string? phone { get; set; }

        // Дата створення запису користувача
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Дата оновлення запису користувача
        public DateTime? UpdatedAt { get; set; }

        // Колекція токенів оновлення для користувача
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
