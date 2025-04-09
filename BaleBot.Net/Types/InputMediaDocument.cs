namespace BaleBot.Net.Types;

public class InputMediaDocument : InputMedia
{
    public string? Thumbnail { get; set; }
    public FileInfo? FileInfo { get; set; }
    public FileInfo? ThumbnailFileInfo { get; set; }

    public InputMediaDocument(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null
    )
    {
        Type = "document";
        Caption = caption;
        Media = fileIdOrUrl;
        Thumbnail = thumbnailFileIdOrUrl;
    }

    public InputMediaDocument(FileInfo file, FileInfo? thumbnailFile = null, string? caption = null)
    {
        Type = "document";
        Caption = caption;
        Media = "<attach://file>";
        FileInfo = file;
        ThumbnailFileInfo = thumbnailFile;
        if (thumbnailFile != null)
        {
            Thumbnail = "<attach://thumbnail>";
        }
    }
}
