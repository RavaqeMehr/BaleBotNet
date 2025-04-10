using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message[]> SendMediaGroup(
        this BaleBotClient bot,
        long chatId,
        InputMediaPhoto[] media,
        long? replyToMessageId = null
    )
    {
        (MultipartFormDataContent multipartFormDataContent, InputMediaMetaData[] metaDatas) =
            media.GetMultipartFormDataContentAndMetaDatas();

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
}
