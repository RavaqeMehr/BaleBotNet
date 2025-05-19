namespace BaleBotNet.Types;

public class InputMediaAnimationForUpload : InputMediaDocumentForUpload
{
    public InputMediaAnimationForUpload(
        FileInfo file,
        FileInfo? thumbnailFile = null,
        string? caption = null
    )
        : base(file, thumbnailFile, caption)
    {
        Type = "animation";
    }
}

public class InputMediaAnimationForFileIdOrUrl : InputMediaDocumentForFileIdOrUrl
{
    public InputMediaAnimationForFileIdOrUrl(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null
    )
        : base(fileIdOrUrl, thumbnailFileIdOrUrl, caption)
    {
        Type = "animation";
    }
}
