using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> IsUserMemberOfChat(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    )
    {
        try
        {
            _ = await bot.SendRequest<object>(
                BotRequest.CreatePost("getChatMember", new { chatId, userId })
            );
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
