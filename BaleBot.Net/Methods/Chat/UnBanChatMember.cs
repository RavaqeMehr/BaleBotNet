namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnBanChatMember(
        this BaleBotClient bot,
        string chatId,
        long userId,
        bool onlyIfBanned
    )
    {
        var request = BotRequest.CreatePost(
            "unbanChatMember",
            new
            {
                chatId,
                userId,
                onlyIfBanned
            }
        );
        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> UnBanChatMember(
        this BaleBotClient bot,
        long chatId,
        long userId,
        bool onlyIfBanned
    ) => await UnBanChatMember(bot, chatId.ToString(), userId, onlyIfBanned);
}
