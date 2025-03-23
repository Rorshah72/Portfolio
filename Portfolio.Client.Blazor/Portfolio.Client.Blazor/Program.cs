using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.Client.Blazor.Components;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Portfolio.Client.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

// Налаштування HttpClient для роботи з API
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7053/api/") };
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    return httpClient;
});

// Додаємо сервіс авторизації (додамо його пізніше)
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
