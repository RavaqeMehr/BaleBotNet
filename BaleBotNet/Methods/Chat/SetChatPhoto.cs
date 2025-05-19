using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<bool> SetChatPhoto(
        this BaleBotClient bot,
        ChatId chatId,
        FileInfo photo
    )
    {
        using FileStream fileStream = new(photo.FullName, FileMode.Open, FileAccess.Read);
        using var fileContent = new StreamContent(fileStream);

        return await bot.SendRequest<bool>(
            BotRequest.CreateForm(
                "setChatPhoto",
                new()
                {
                    { new StringContent(chatId.ToString()), "chat_id" },
                    { fileContent, "photo", Path.GetFileName(photo.FullName) }
                }
            )
        );
    }
}
