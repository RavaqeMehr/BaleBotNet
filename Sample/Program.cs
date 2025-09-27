// OLD SAMPLES ARE IN PROGRAM.CS.OLD

using System.Text.Json;
using BaleBotNet;
using BaleBotNet.Methods;
using BaleBotNet.Types;
using Sample;
using Sample.UpdateHandlers;

var builder = WebApplication.CreateBuilder(args);

var env =
    JsonSerializer.Deserialize<Env>(await System.IO.File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

var bot = builder.Services.AddBaleBotClient(env.Token);

#region Updates

// For Handling Updates Use This:
// builder.Services.AddScoped<IUpdateHandler, UpdateHandler>();

// Or These:
// builder.Services.AddScoped<IMessageUpdateHandler, MessageUpdateHandler>();
// builder.Services.AddScoped<IEditedMessageUpdateHandler, EditedMessageUpdateHandler>();
// builder.Services.AddScoped<ICallbackQueryUpdateHandler, CallbackQueryUpdateHandler>();
// builder.Services.AddScoped<IPreCheckoutQueryUpdateHandler, PreCheckoutQueryUpdateHandler>();

var app = builder.Build();

// For Handling Updates Use This for webhook:
// app.MapBaleBotWebhookWithSepratedHandleres(env.AppBaseUrl);

// Or this for polling:

// await Task.Run(
//     async () =>
//     {
//         var sp = app.Services.GetRequiredService<IServiceScopeFactory>();
//         int? offset = null;
//         do
//         {
//             var updates = await bot.GetUpdates(offset, 10);
//             Console.WriteLine("========================================");
//             Console.WriteLine($"Updates: {updates?.Length ?? 0}");
//             await Task.Delay(1000);

//             List<Task>? tasks = updates
//                 ?.Select(
//                     async (update) =>
//                     {
//                         var updateId = update.UpdateId;
//                         using var scope = sp.CreateScope();
//                         var updateTask = update switch
//                         {
//                             { Message: { } message }
//                                 => scope
//                                     .ServiceProvider.GetRequiredService<IMessageUpdateHandler>()
//                                     .HandleUpdate(
//                                         updateId,
//                                         message,
//                                         app.Lifetime.ApplicationStopping
//                                     ),
//                             { EditedMessage: { } editedMessage }
//                                 => scope
//                                     .ServiceProvider.GetRequiredService<IEditedMessageUpdateHandler>()
//                                     .HandleUpdate(
//                                         updateId,
//                                         editedMessage,
//                                         app.Lifetime.ApplicationStopping
//                                     ),
//                             { CallbackQuery: { } callbackQuery }
//                                 => scope
//                                     .ServiceProvider.GetRequiredService<ICallbackQueryUpdateHandler>()
//                                     .HandleUpdate(
//                                         updateId,
//                                         callbackQuery,
//                                         app.Lifetime.ApplicationStopping
//                                     ),
//                             { PreCheckoutQuery: { } preCheckoutQuery }
//                                 => scope
//                                     .ServiceProvider.GetRequiredService<IPreCheckoutQueryUpdateHandler>()
//                                     .HandleUpdate(
//                                         updateId,
//                                         preCheckoutQuery,
//                                         app.Lifetime.ApplicationStopping
//                                     ),
//                             _ => Task.CompletedTask
//                         };

//                         try
//                         {
//                             await updateTask;
//                             await Task.Delay(3000); // for avoiding Too Many Requests error
//                         }
//                         catch (Exception ex)
//                         {
//                             if (ex.Message?.Contains("Too Many Requests") == true)
//                             {
//                                 Console.WriteLine("Too Many Requests Error: waiting 20 sec");
//                                 await Task.Delay(20000); // for avoiding Too Many Requests error

//                                 return;
//                             }
//                             else
//                             {
//                                 throw;
//                             }
//                         }
//                     }
//                 )
//                 .ToList();

//             if (tasks != null)
//             {
//                 await Task.WhenAll(tasks);
//             }
//             if (updates != null && updates.Length > 0)
//             {
//                 offset = updates?.Last().UpdateId + 1;
//             }
//         } while (app.Lifetime.ApplicationStopping.IsCancellationRequested == false);
//     },
//     app.Lifetime.ApplicationStopping
// );

#endregion



// app.Run();



ShortSamples samples = new(bot);

// await samples.SendInvoice(env.TestChatId);
// await samples.InquireTransaction("");

// await samples.SendChatAction(env.TestChatId);
// await samples.RequestContact(env.TestChatId);
// await samples.InlineButtons(env.TestChatId);
// await samples.KeyboardButtons(env.TestChatId);
await samples.CreateInvoiceLink();

// await samples.SendPhoto(env.TestChatId);


// simple use for saving updates for tests
// Directory.CreateDirectory("updates");
// await Task.Run(
//     async () =>
//     {
//         int? offset = null;
//         do
//         {
//             var updates = await bot.GetUpdates(offset, 10);
//             Console.WriteLine("========================================");
//             Console.WriteLine($"Updates: {updates?.Length ?? 0}");

//             if (updates != null && updates.Length > 0)
//             {
//                 foreach (var update in updates)
//                 {
//                     await System.IO.File.WriteAllTextAsync(
//                         $"updates/{update.UpdateId}.json",
//                         BaleBotClient.SerializeToJson(update, true)
//                     );

//                     if (update.PreCheckoutQuery is PreCheckoutQuery preCheckoutQuery)
//                     {
//                         try
//                         {
//                             await bot.AnswerPreCheckoutQuery(preCheckoutQuery.Id, true); // تایید پرداخت
//                             await bot.AnswerPreCheckoutQuery(
//                                 preCheckoutQuery.Id,
//                                 false,
//                                 "موجودی این محصول به اتمام رسید!"
//                             ); // عدم تایید پرداخت
//                         }
//                         catch { }
//                     }
//                 }

//                 offset = updates?.Last().UpdateId + 1;
//             }

//             await Task.Delay(500);
//         } while (app.Lifetime.ApplicationStopping.IsCancellationRequested == false);
//     },
//     app.Lifetime.ApplicationStopping
// );
