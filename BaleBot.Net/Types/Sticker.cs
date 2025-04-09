namespace BaleBot.Net.Types;

public class Sticker
{
    public string FileId { get; set; } = default!;
    public string FileUniqueId { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int Width { get; set; }
    public int Height { get; set; }
    public long? FileSize { get; set; }
}
