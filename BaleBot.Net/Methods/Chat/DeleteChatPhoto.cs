using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteChatPhoto(this BaleBotClient bot, string chatId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "deleteChatPhoto")
        {
            Content = JsonContent.Create(new { chat_id = chatId })
        };

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> DeleteChatPhoto(this BaleBotClient bot, long chatId) =>
        await DeleteChatPhoto(bot, chatId.ToString());
}
