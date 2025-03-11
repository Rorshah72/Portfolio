using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Shared.Infrastructure.Api
{
    public class ApiResponse<T>
    {
        // Властивість, що вказує на успішність відповіді
        public bool Success { get; set; }

        // Дані відповіді
        public T? Data { get; set; }

        // Повідомлення про помилку, якщо відповідь неуспішна
        public string? ErrorMessage { get; set; }

        // Метод для створення успішної відповіді
        public static ApiResponse<T> SuccessResponse(T data)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data
            };
        }

        // Метод для створення відповіді з помилкою
        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                ErrorMessage = message
            };
        }
    }
}
