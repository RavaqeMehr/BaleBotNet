namespace BaleBotNet.Types;

public class File
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public long FileSize { get; set; }
    public string? FilePath { get; set; }

    public string FileUrl(BaleBotClient bot) => GetFileUrl(bot, FileId);

    public static String GetFileUrl(BaleBotClient bot, string fileId) =>
        $"https://tapi.bale.ai/file/{bot.Token}/{fileId}";
}
