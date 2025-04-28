using System.Net.Http.Headers;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    private enum SendMethod
    {
        SendPhoto,
        SendAudio,
        SendDocument,
        SendVideo,
        SendAnimation,
        SendVoice
    }

    private static string GetMethodUrl(this SendMethod sendMethod) =>
        sendMethod switch
        {
            SendMethod.SendPhoto => "sendPhoto",
            SendMethod.SendAudio => "sendAudio",
            SendMethod.SendVideo => "sendVideo",
            SendMethod.SendAnimation => "sendAnimation",
            SendMethod.SendVoice => "sendVoice",
            _ => "sendDocument"
        };

    private static MediaTypeHeaderValue GetContentType(this SendMethod sendMethod) =>
        new MediaTypeHeaderValue(
            sendMethod switch
            {
                SendMethod.SendPhoto => "image/jpeg",
                SendMethod.SendAudio => "audio/mpeg",
                SendMethod.SendVideo => "video/mp4",
                SendMethod.SendAnimation => "image/gif",
                SendMethod.SendVoice => "audio/ogg",
                _ => "application/octet-stream"
            }
        );

    private static string GetFieldName(this SendMethod sendMethod) =>
        sendMethod switch
        {
            SendMethod.SendPhoto => "photo",
            SendMethod.SendAudio => "audio",
            SendMethod.SendVideo => "video",
            SendMethod.SendAnimation => "animation",
            SendMethod.SendVoice => "voice",
            _ => "document"
        };

    private static async Task<Message> SendFile(
        this BaleBotClient bot,
        SendMethod sendMethod,
        string chatId,
        string fileIdOrUrl,
        string? caption = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        Dictionary<string, object?> body =
            new()
            {
                ["chatId"] = chatId,
                [sendMethod.GetFieldName()] = fileIdOrUrl,
                ["caption"] = caption,
                ["replyToMessageId"] = replyToMessageId,
                ["replyMarkup"] = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
            };

        var request = BotRequest.CreatePost(sendMethod.GetMethodUrl(), body);

        return await bot.SendRequest<Message>(request);
    }

    private static async Task<Message> SendFile(
        this BaleBotClient bot,
        SendMethod sendMethod,
        string chatId,
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

        using var form = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            { fileContent, sendMethod.GetFieldName(), fileName ?? fileInfo.Name }
        };

        if (!string.IsNullOrEmpty(caption))
        {
            form.Add(new StringContent(caption), "caption");
        }

        if (replyToMessageId is long replyId)
        {
            form.Add(new StringContent(replyId.ToString()), "reply_to_message_id");
        }

        if (replyMarkup != null)
        {
            form.Add(
                new StringContent(replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"),
                "reply_markup"
            );
        }

        using var request = BotRequest.CreateForm(sendMethod.GetMethodUrl(), form);

        return await bot.SendRequest<Message>(request);
    }
}
