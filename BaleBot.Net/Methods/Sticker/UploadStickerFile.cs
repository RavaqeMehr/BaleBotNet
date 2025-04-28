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

        return await bot.SendRequest<Sticker>(
            BotRequest.CreateForm(
                "uploadStickerFile",
                new()
                {
                    { new StringContent(userId.ToString()), "user_id" },
                    { fileContent, "sticker", Path.GetFileName(sticker.FullName) }
                }
            )
        );
    }
}
