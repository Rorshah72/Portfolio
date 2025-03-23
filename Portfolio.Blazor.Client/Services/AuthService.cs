using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Portfolio.Shared.Models;
using Portfolio.Shared.Models.DTOs;

public class AuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login", request);
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<LoginResponse>();
    }
}
