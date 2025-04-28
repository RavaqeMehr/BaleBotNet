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

        using var request = BotRequest.CreateForm(
            "setChatPhoto",
            new()
            {
                { new StringContent(chatId.ToString()), "chat_id" },
                { fileContent, "photo", Path.GetFileName(photo.FullName) }
            }
        );

        return await bot.SendRequest<bool>(request);
    }

    [Obsolete("Throws Error: Bale Api not work correctly")]
    public static async Task<bool> SetChatPhoto(
        this BaleBotClient bot,
        long chatId,
        FileInfo photo
    ) => await SetChatPhoto(bot, chatId.ToString(), photo);
}
