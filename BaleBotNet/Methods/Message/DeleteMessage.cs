using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteMessage(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost("deleteMessage", new { chatId, messageId })
        );
}

public static partial class MessageExtentions
{
    public static async Task<bool> Delete(this Message message, BaleBotClient bot) =>
        await bot.DeleteMessage(message.Chat.Id, message.MessageId);
}
