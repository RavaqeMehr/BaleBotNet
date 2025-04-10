using System.Net.Http.Headers;
using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    private enum SendMethod
    {
        SendPhoto,
        SendAudio,
        SendDocument,
        SendVideo
    }

    private static string GetMethodUrl(this SendMethod sendMethod) =>
        sendMethod switch
        {
            SendMethod.SendPhoto => "sendPhoto",
            SendMethod.SendAudio => "sendAudio",
            SendMethod.SendVideo => "sendVideo",
            SendMethod.SendDocument => "sendDocument",
            _ => throw new ArgumentOutOfRangeException(nameof(sendMethod), sendMethod, null)
        };

    private static MediaTypeHeaderValue GetContentType(this SendMethod sendMethod) =>
        new MediaTypeHeaderValue(
            sendMethod switch
            {
                SendMethod.SendPhoto => "image/jpeg",
                SendMethod.SendAudio => "audio/mpeg",
                SendMethod.SendVideo => "video/mp4",
                SendMethod.SendDocument => "application/octet-stream",
                _ => throw new ArgumentOutOfRangeException(nameof(sendMethod), sendMethod, null)
            }
        );

    private static string GetFieldName(this SendMethod sendMethod) =>
        sendMethod switch
        {
            SendMethod.SendPhoto => "photo",
            SendMethod.SendAudio => "audio",
            SendMethod.SendVideo => "video",
            SendMethod.SendDocument => "document",
            _ => throw new ArgumentOutOfRangeException(nameof(sendMethod), sendMethod, null)
        };

    private static async Task<Message> SendFile(
        this BaleBotClient bot,
        SendMethod sendMethod,
        long chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        Dictionary<string, object?> body =
            new()
            {
                ["chat_id"] = chatId,
                [sendMethod.GetFieldName()] = fileIdOrUrl,
                ["caption"] = caption,
                ["reply_to_message_id"] = replyToMessageId,
                ["reply_markup"] = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
            };

        var request = new HttpRequestMessage(HttpMethod.Post, sendMethod.GetMethodUrl())
        {
            Content = JsonContent.Create(body)
        };

        return await bot.SendRequest<Message>(request);
    }

    private static async Task<Message> SendFile(
        this BaleBotClient bot,
        SendMethod sendMethod,
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
        fileContent.Headers.ContentType = sendMethod.GetContentType();

        using var content = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            { fileContent, sendMethod.GetFieldName(), fileName ?? fileInfo.Name }
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

        using var request = new HttpRequestMessage(HttpMethod.Post, sendMethod.GetMethodUrl())
        {
            Content = content
        };

        return await bot.SendRequest<Message>(request);
    }
}
