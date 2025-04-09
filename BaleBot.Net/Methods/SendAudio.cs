using System.Net.Http.Headers;
using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendAudio(
        this BaleBotClient bot,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendAudio")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    audio = fileIdOrUrl,
                    caption,
                    reply_to_message_id = replyToMessageId,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendAudio(
        this BaleBotClient bot,
        long chatId,
        FileInfo fileInfo,
        string? fileName = null,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");

        using var content = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            { fileContent, "audio", fileName ?? fileInfo.Name }
        };

        if (!string.IsNullOrEmpty(caption))
        {
            content.Add(new StringContent(caption), "caption");
        }

        if (replyToMessageId is long replyId)
        {
            content.Add(new StringContent(replyId.ToString()), "reply_to_message_id");
        }

        if (replyMarkup != null)
        {
            content.Add(
                new StringContent(replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"),
                "reply_markup"
            );
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, "sendAudio")
        {
            Content = content
        };

        return await bot.SendRequest<Message>(request);
    }
}
