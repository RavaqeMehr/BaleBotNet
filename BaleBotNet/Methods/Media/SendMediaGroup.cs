using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    #region For Upload
    private static async Task<Message[]> InternalSendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaForUpload[] media,
        long? replyToMessageId = null
    )
    {
        var (form, metaDatas) = media.GetMultipartFormDataContentAndMetaDatas();

        form.Add(new StringContent(chatId.ToString()), "chat_id");

        if (replyToMessageId is long replyId)
        {
            form.Add(new StringContent(replyId.ToString()), "reply_to_message_id");
        }

        var mediaJson = Shared.SerializeToJson(metaDatas)!;
        form.Add(new StringContent(mediaJson), "media");

        return await bot.SendRequest<Message[]>(BotRequest.CreateForm("sendMediaGroup", form));
    }

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaPhotoForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaVideoForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaDocumentForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaAudioForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaAnimationForUpload[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    #endregion


    #region For FileIdOrUrl

    private static async Task<Message[]> InternalSendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) =>
        await bot.SendRequest<Message[]>(
            BotRequest.CreatePost(
                "sendMediaGroup",
                new
                {
                    chatId,
                    media,
                    replyToMessageId
                }
            )
        );

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaPhotoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaVideoForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaDocumentForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaAudioForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    // has error
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        ChatId chatId,
        InputMediaAnimationForFileIdOrUrl[] media,
        long? replyToMessageId = null
    ) => await bot.InternalSendMediaGroup(chatId, media, replyToMessageId);

    #endregion
}
