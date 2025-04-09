namespace BaleBot.Net.Types;

public class File
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public long FileSize { get; set; }
    public string? FilePath { get; set; }

    public string? FileUrl(BaleBotClient bot) =>
        FilePath == null ? null : $"https://tapi.bale.ai/file/{bot.Token}/{FilePath}";
}
