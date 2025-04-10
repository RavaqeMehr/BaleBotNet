using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendVideo(
        this BaleBotClient bot,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendFile(
            bot,
            SendMethod.SendVideo,
            chatId,
            fileIdOrUrl,
            caption,
            replyToMessageId,
            replyMarkup
        );

    public static async Task<Message> SendVideo(
        this BaleBotClient bot,
        long chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendFile(
            bot,
            SendMethod.SendVideo,
            chatId,
            fileInfo,
            fileName,
            caption,
            replyToMessageId,
            replyMarkup
        );
}
