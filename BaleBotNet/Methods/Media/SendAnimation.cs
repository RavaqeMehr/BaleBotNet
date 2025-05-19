using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    // Commented because has server error
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        ChatId chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendFile(
            SendMethod.SendAnimation,
            chatId,
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendAnimation(
        this BaleBotClient bot,
        ChatId chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendFile(
            SendMethod.SendAnimation,
            chatId,
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );
}
