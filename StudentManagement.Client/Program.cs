using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentManagement.Client;
using StudentManagement.Client.Services;
using StudentManagement.Shared.StudentRepository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddScoped<IStudentRepository, StudentService>();
builder.Services.AddScoped(sp =>
{
    var baseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!);
    return new HttpClient { BaseAddress = baseAddress };
});

await builder.Build().RunAsync();
