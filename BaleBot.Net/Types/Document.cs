namespace BaleBot.Net.Types;

public class Document
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public PhotoSize? Thumbnail { get; set; }
    public string? FileName { get; set; }
    public string? MimeType { get; set; }
    public long? FileSize { get; set; }
}
