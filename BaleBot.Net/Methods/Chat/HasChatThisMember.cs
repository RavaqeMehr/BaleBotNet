namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> HasChatThisMember(
        this BaleBotClient bot,
        string chatId,
        long userId
    ) => await UnBanChatMember(bot, chatId, userId, true);
}
