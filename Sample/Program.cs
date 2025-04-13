// OLD SAMPLES ARE IN PROGRAM.CS.OLD

using System.Text.Json;
using BaleBot.Net;
using BaleBot.Net.Methods;
using BaleBot.Net.Types;
using Sample.UpdateHandlers;

var builder = WebApplication.CreateBuilder(args);

var env =
    JsonSerializer.Deserialize<Env>(await System.IO.File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

var bot = builder.Services.AddBaleBotClient(env.Token);

// For Handling Updates Use This:
builder.Services.AddScoped<IUpdateHandler, UpdateHandler>();

// Or These:
builder.Services.AddScoped<IMessageUpdateHandler, MessageUpdateHandler>();
builder.Services.AddScoped<IEditedMessageUpdateHandler, EditedMessageUpdateHandler>();
builder.Services.AddScoped<ICallbackQueryUpdateHandler, CallbackQueryUpdateHandler>();
builder.Services.AddScoped<IPreCheckoutQueryUpdateHandler, PreCheckoutQueryUpdateHandler>();

var app = builder.Build();

// For Handling Updates Use These for webhook:
// app.MapBaleBotWebhookWithSepratedHandleres(env.AppBaseUrl);
// app.MapBaleBotValidateInitDataApi();

// Or this for polling:

await Task.Run(
    async () =>
    {
        var sp = app.Services.GetRequiredService<IServiceScopeFactory>();
        int? offset = null;
        do
        {
            var updates = await bot.GetUpdates(offset, 10);
            Console.WriteLine("========================================");
            Console.WriteLine($"Updates: {updates?.Count() ?? 0}");
            await Task.Delay(1000);

            List<Task>? tasks = updates
                ?.Select(
                    async (update) =>
                    {
                        var updateId = update.UpdateId;
                        using var scope = sp.CreateScope();
                        var updateTask = update switch
                        {
                            { Message: { } message }
                                => scope
                                    .ServiceProvider.GetRequiredService<IMessageUpdateHandler>()
                                    .HandleUpdate(
                                        updateId,
                                        message,
                                        app.Lifetime.ApplicationStopping
                                    ),
                            { EditedMessage: { } editedMessage }
                                => scope
                                    .ServiceProvider.GetRequiredService<IEditedMessageUpdateHandler>()
                                    .HandleUpdate(
                                        updateId,
                                        editedMessage,
                                        app.Lifetime.ApplicationStopping
                                    ),
                            { CallbackQuery: { } callbackQuery }
                                => scope
                                    .ServiceProvider.GetRequiredService<ICallbackQueryUpdateHandler>()
                                    .HandleUpdate(
                                        updateId,
                                        callbackQuery,
                                        app.Lifetime.ApplicationStopping
                                    ),
                            { PreCheckoutQuery: { } preCheckoutQuery }
                                => scope
                                    .ServiceProvider.GetRequiredService<IPreCheckoutQueryUpdateHandler>()
                                    .HandleUpdate(
                                        updateId,
                                        preCheckoutQuery,
                                        app.Lifetime.ApplicationStopping
                                    ),
                            _ => Task.CompletedTask
                        };

                        try
                        {
                            await updateTask;
                            await Task.Delay(3000); // for avoiding Too Many Requests error
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message?.Contains("Too Many Requests") == true)
                            {
                                Console.WriteLine("Too Many Requests Error: waiting 20 sec");
                                await Task.Delay(20000); // for avoiding Too Many Requests error

                                return;
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                )
                .ToList();

            if (tasks != null)
            {
                await Task.WhenAll(tasks);
            }
            if (updates != null && updates.Length > 0)
            {
                offset = updates?.Max(x => x.UpdateId) + 1;
            }
        } while (app.Lifetime.ApplicationStopping.IsCancellationRequested == false);
    },
    app.Lifetime.ApplicationStopping
);

app.Run();
