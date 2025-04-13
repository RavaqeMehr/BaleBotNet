using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    #region For Upload
    private static async Task<Message[]> InternalSendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaForUpload[] media,
        long? replyToMessageId = null
    )
    {
        (
            MultipartFormDataContent multipartFormDataContent,
            InputMediaForUploadMetaData[] metaDatas
        ) = media.GetMultipartFormDataContentAndMetaDatas();

        multipartFormDataContent.Add(new StringContent(chatId.ToString()), "chat_id");

        if (replyToMessageId is long replyId)
        {
            multipartFormDataContent.Add(
                new StringContent(replyId.ToString()),
                "reply_to_message_id"
            );
        }

        var mediaJson = BaleBotClient.SerializeToJson(metaDatas)!;
        multipartFormDataContent.Add(new StringContent(mediaJson), "media");

        using var request = new HttpRequestMessage(HttpMethod.Post, "sendMediaGroup")
        {
            Content = multipartFormDataContent
        };

        return await bot.SendRequest<Message[]>(request);
    }

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaPhotoForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaPhotoForUpload[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaVideoForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaVideoForUpload[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaDocumentForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaDocumentForUpload[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaAudioForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaAudioForUpload[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaAnimationForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaAnimationForUpload[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    #endregion


    #region For FileIdOrUrl

    private static async Task<Message[]> InternalSendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaForFileIdOrUrl[] media,
        long? replyToMessageId = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendMediaGroup")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    media,
                    reply_to_message_id = replyToMessageId
                }
            )
        };

        return await bot.SendRequest<Message[]>(request);
    }

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaPhotoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaPhotoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaVideoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaVideoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaDocumentForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaDocumentForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaAudioForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaAudioForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    // has error
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        string chatId,
        InputMediaAnimationForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaAnimationForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await SendMediaGroup(bot, chatId.ToString(), media, replyToMessageId);

    #endregion
}
