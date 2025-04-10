using System.Net.Http.Headers;
using System.Net.Mime;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatPhoto(
        this BaleBotClient bot,
        string chatId,
        FileInfo photo
    )
    {
        using FileStream fileStream = new(photo.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Image.Jpeg);

        using var content = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            { fileContent, "photo", "" }
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "setChatPhoto")
        {
            Content = content
        };

        return await bot.SendRequest<bool>(request);
    }
}
