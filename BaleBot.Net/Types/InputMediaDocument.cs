namespace BaleBot.Net.Types;

public class InputMediaDocument : InputMedia
{
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
        FileInfo = file;
        ThumbnailFileInfo = thumbnailFile;
    }
}
