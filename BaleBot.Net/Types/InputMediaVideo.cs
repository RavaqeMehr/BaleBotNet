namespace BaleBot.Net.Types;

public class InputMediaVideoForUpload : InputMediaDocumentForUpload
{
    public InputMediaVideoForUpload(
        FileInfo file,
        FileInfo? thumbnailFile = null,
        string? caption = null
    )
        : base(file, thumbnailFile, caption)
    {
        Type = "video";
    }
}

public class InputMediaVideoForFileIdOrUrl : InputMediaDocumentForFileIdOrUrl
{
    public InputMediaVideoForFileIdOrUrl(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null
    )
        : base(fileIdOrUrl, thumbnailFileIdOrUrl, caption)
    {
        Type = "video";
    }
}
