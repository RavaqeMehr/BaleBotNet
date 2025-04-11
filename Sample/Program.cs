// OLD SAMPLES ARE IN PROGRAM.CS.OLD

using System.Text.Json;
using BaleBot.Net;
using BaleBot.Net.Types;

var builder = WebApplication.CreateBuilder(args);

var env =
    JsonSerializer.Deserialize<Env>(await System.IO.File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

builder.Services.AddBaleBotClient(env.Token);

var app = builder.Build();

app.MapBaleBotWebhook(
    env.AppBaseUrl,
    async (Update update) =>
    {
        using var scope = app.Services.CreateScope();
    }
);

app.Run();
