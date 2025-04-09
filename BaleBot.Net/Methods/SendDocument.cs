using System.Net.Http.Headers;
using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendDocument")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    document = fileIdOrUrl,
                    caption,
                    reply_to_message_id = replyToMessageId,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendDocument(
        this BaleBotClient bot,
        long chatId,
        FileInfo fileInfo,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        using var content = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            { fileContent, "document", fileInfo.Name }
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

        using var request = new HttpRequestMessage(HttpMethod.Post, "sendDocument")
        {
            Content = content
        };

        return await bot.SendRequest<Message>(request);
    }
}
