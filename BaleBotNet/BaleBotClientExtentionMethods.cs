using BaleBotNet.Methods;
using BaleBotNet.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BaleBotNet;

public static class BaleBotClientExtentionMethods
{
    public static BaleBotClient AddBaleBotClient(
        this IServiceCollection services,
        string token,
        int timeout = 60
    )
    {
        BaleBotClient baleBotClient = new(token, timeout);
        services.AddSingleton(baleBotClient);

        return baleBotClient;
    }

    private static string SetWebhook(WebApplication app, string appBaseUrl, string webhookPrefix)
    {
        var bot = app.Services.GetRequiredService<BaleBotClient>();

        var salt = Guid.NewGuid().ToString().Replace("-", "");
        var webhookPath = $"{webhookPrefix}/{salt}";
        var webhookUrl = $"{appBaseUrl}{webhookPath}";

        Console.WriteLine($"Webhook URL: {webhookUrl}");
        Console.WriteLine($"Webhook Path: {webhookPath}");

        _ = bot.SetWebhook(webhookUrl).Result;

        return webhookPath;
    }

    public static WebApplication MapBaleBotWebhook(
        this WebApplication app,
        string appBaseUrl,
        Func<Message, Task> handleMessage,
        Func<Message, Task> handleEditedMessage,
        Func<CallbackQuery, Task> handleCallbackQuery,
        Func<PreCheckoutQuery, Task> handlePreCheckoutQuery,
        string webhookPrefix = "/integrations/bale/update-webhook"
    )
    {
        var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

        app.MapPost(
            webhookPath,
            async (HttpRequest request) =>
            {
                Update update = await GetUpdateFromHttpRequest(request);

                switch (update)
                {
                    case { Message: { } message }:
                        await handleMessage(message);
                        break;
                    case { EditedMessage: { } editedMessage }:
                        await handleEditedMessage(editedMessage);
                        break;
                    case { CallbackQuery: { } callbackQuery }:
                        await handleCallbackQuery(callbackQuery);
                        break;
                    case { PreCheckoutQuery: { } preCheckoutQuery }:
                        await handlePreCheckoutQuery(preCheckoutQuery);
                        break;

                    default:
                        throw new NotImplementedException(
                            $"Update type {update.GetType()} not implemented."
                        );
                }
            }
        );

        return app;
    }

    public static WebApplication MapBaleBotWebhook(
        this WebApplication app,
        string appBaseUrl,
        Func<Update, Task> handleUpdate,
        string webhookPrefix = "/integrations/bale/update-webhook"
    )
    {
        var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

        app.MapPost(
            webhookPath,
            async (HttpRequest request) =>
            {
                Update update = await GetUpdateFromHttpRequest(request);

                await handleUpdate(update);
            }
        );

        return app;
    }

    public static WebApplication MapBaleBotWebhook(
        this WebApplication app,
        string appBaseUrl,
        string webhookPrefix = "/integrations/bale/update-webhook"
    )
    {
        var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

        app.MapPost(
            webhookPath,
            async (IUpdateHandler updateHandler, HttpRequest request) =>
            {
                Update update = await GetUpdateFromHttpRequest(request);

                await updateHandler.HandleUpdate(update);
            }
        );

        return app;
    }

    public static WebApplication MapBaleBotWebhookWithSepratedHandleres(
        this WebApplication app,
        string appBaseUrl,
        string webhookPrefix = "/integrations/bale/update-webhook"
    )
    {
        var webhookPath = SetWebhook(app, appBaseUrl, webhookPrefix);

        app.MapPost(
            webhookPath,
            async Task (IServiceScopeFactory serviceScopeFactory, HttpRequest request) =>
            {
                Update update = await GetUpdateFromHttpRequest(request);

                var updateId = update.UpdateId;
                using var scope = serviceScopeFactory.CreateScope();
                var updateTask = update switch
                {
                    { Message: { } message }
                        => scope
                            .ServiceProvider.GetRequiredService<IMessageUpdateHandler>()
                            .HandleUpdate(updateId, message),
                    { EditedMessage: { } editedMessage }
                        => scope
                            .ServiceProvider.GetRequiredService<IEditedMessageUpdateHandler>()
                            .HandleUpdate(updateId, editedMessage),
                    { CallbackQuery: { } callbackQuery }
                        => scope
                            .ServiceProvider.GetRequiredService<ICallbackQueryUpdateHandler>()
                            .HandleUpdate(updateId, callbackQuery),
                    { PreCheckoutQuery: { } preCheckoutQuery }
                        => scope
                            .ServiceProvider.GetRequiredService<IPreCheckoutQueryUpdateHandler>()
                            .HandleUpdate(updateId, preCheckoutQuery),
                    _ => Task.CompletedTask
                };

                await updateTask;
            }
        );

        return app;
    }

    public static async Task<Update> GetUpdateFromHttpRequest(HttpRequest request) =>
        (await request.ReadFromJsonAsync<Update>(BaleBotNetJsonTools.jsonOption))!;
}
