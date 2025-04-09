using System.Text.Json;
using BaleBot.Net;
using BaleBot.Net.Methods;

var env =
    JsonSerializer.Deserialize<Env>(await File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

var bot = new BaleBotClient(env.Token + "12345");
var me = await bot.GetMe();

Console.WriteLine($"Hello, World! I'm @{me.Username} !");
