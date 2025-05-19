namespace BaleBotNet.Types;

public class Video
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public int Width { get; set; }
    public int Height { get; set; }
    public int Duration { get; set; }
    public string? FileName { get; set; }
    public string? MimeType { get; set; }
    public long? FileSize { get; set; }
}
