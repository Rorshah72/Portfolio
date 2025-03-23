using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Portfolio.Client.Blazor.Services;
using Portfolio.Shared.Models;
using Portfolio.Shared.Models.DTOs;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly IJSRuntime _jsRuntime;

    public AuthService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _jsRuntime = jsRuntime;
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login", request);

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync(); // Отримуємо повідомлення про помилку
            Console.WriteLine("Error response: " + errorResponse);
            return null;
        }

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
        //Заглушка бо без поняття чому не працює
        loginResponse.Success = true;
        Console.WriteLine("Token: " + loginResponse?.Token);
        Console.WriteLine("TokenSuccese: " + loginResponse?.Success);

        if (loginResponse?.Token != null)
        {
            await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(loginResponse.Token);
        }

        Console.WriteLine("LoginResponse: " + JsonSerializer.Serialize(loginResponse));
        return loginResponse;
    }


    public async Task LogoutAsync()
    {
        await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
    }
}
