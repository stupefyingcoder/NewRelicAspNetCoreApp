using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return "Hi from .NET Core – New Relic demo app";
});

app.MapGet("/error", () =>
{
    throw new Exception("Simulated error for New Relic APM");
});

app.MapGet("/slow", async () =>
{
    await Task.Delay(4000); // 4 seconds
    return "Slow response completed";
});

app.Run();
