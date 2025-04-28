namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> IsUserMemberOfChat(
        this BaleBotClient bot,
        string chatId,
        long userId
    )
    {
        if (!chatId.StartsWith('@'))
        {
            if (!long.TryParse(chatId, out _))
            {
                chatId = $"@{chatId}";
            }
        }

        var request = BotRequest.CreatePost("getChatMember", new { chatId, userId });

        try
        {
            _ = await bot.SendRequest<object>(request);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static async Task<bool> IsUserMemberOfChat(
        this BaleBotClient bot,
        long chatId,
        long userId
    ) => await IsUserMemberOfChat(bot, chatId.ToString(), userId);
}
