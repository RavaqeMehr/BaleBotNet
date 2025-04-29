using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> AnswerCallbackQuery(
        this BaleBotClient bot,
        string callbackQueryId,
        string? text,
        bool? showAlert = false,
        int? cacheTime = 0
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost(
                "answerCallbackQuery",
                new
                {
                    callbackQueryId,
                    text,
                    showAlert,
                    cacheTime
                }
            )
        );
}

public static partial class CallbackQueryExtentions
{
    public static async Task<bool> Answer(
        this CallbackQuery callbackQuery,
        BaleBotClient bot,
        string? text,
        bool? showAlert = false,
        int? cacheTime = 0
    ) => await bot.AnswerCallbackQuery(callbackQuery.Id, text, showAlert, cacheTime);
}
