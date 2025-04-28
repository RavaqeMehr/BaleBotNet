using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteChatPhoto(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("deleteChatPhoto", new { chatId }));
}
