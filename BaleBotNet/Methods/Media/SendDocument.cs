using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        ChatId chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendFile(
            SendMethod.SendDocument,
            chatId,
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        ChatId chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendFile(
            SendMethod.SendDocument,
            chatId,
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );
}
