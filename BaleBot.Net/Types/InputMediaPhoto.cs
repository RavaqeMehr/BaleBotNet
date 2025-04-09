namespace BaleBot.Net.Types;

public class InputMediaPhoto : InputMedia
{
    public FileInfo? FileInfo { get; set; }

    public InputMediaPhoto(string fileIdOrUrl, string? caption = null)
    {
        Type = "photo";
        Caption = caption;
        Media = fileIdOrUrl;
    }

    public InputMediaPhoto(FileInfo file, string? caption = null)
    {
        Type = "photo";
        Caption = caption;
        Media = "<attach://file>";
        FileInfo = file;
    }
}
