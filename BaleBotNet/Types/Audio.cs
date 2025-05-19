namespace BaleBotNet.Types;

public class Audio
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public int Duration { get; set; }
    public string? Title { get; set; }
    public string? FileName { get; set; }
    public string? MimeType { get; set; }
    public long? FileSize { get; set; }
}
