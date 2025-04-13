using System.Net.Http.Headers;
using System.Net.Mime;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<bool> SetChatPhoto(
        this BaleBotClient bot,
        string chatId,
        FileInfo photo
    )
    {
        using FileStream fileStream = new(photo.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);
        // fileContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Image.Jpeg);

        using var form = new MultipartFormDataContent
        {
            { new StringContent(chatId.ToString()), "chat_id" },
            // { new StringContent("<attach://photo>"), "photo" },
            { fileContent, "photo", Path.GetFileName(photo.FullName) }
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "setChatPhoto")
        {
            Content = form
        };

        return await bot.SendRequest<bool>(request);
    }

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<bool> SetChatPhoto(
        this BaleBotClient bot,
        long chatId,
        FileInfo photo
    ) => await SetChatPhoto(bot, chatId.ToString(), photo);
}
