namespace BaleBotNet.Types;

public class InputMediaDocumentForUpload : InputMediaForUpload
{
    public InputMediaDocumentForUpload(
        FileInfo file,
        FileInfo? thumbnailFile = null,
        string? caption = null
    )
    {
        Type = "document";
        Caption = caption;
        FileInfo = file;
        ThumbnailFileInfo = thumbnailFile;
    }
}

public class InputMediaDocumentForFileIdOrUrl : InputMediaForFileIdOrUrl
{
    public InputMediaDocumentForFileIdOrUrl(
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
}
