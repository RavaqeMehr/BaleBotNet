using System.Net.Http.Headers;
using System.Net.Mime;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Sticker> UploadStickerFile(
        this BaleBotClient bot,
        long userId,
        FileInfo sticker
    )
    {
        using FileStream fileStream = new(sticker.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);
        // fileContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Image.Jpeg);

        using var form = new MultipartFormDataContent
        {
            { new StringContent(userId.ToString()), "user_id" },
            { fileContent, "sticker", Path.GetFileName(sticker.FullName) }
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "uploadStickerFile")
        {
            Content = form
        };

        return await bot.SendRequest<Sticker>(request);
    }
}
