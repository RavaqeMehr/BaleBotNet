namespace BaleBotNet.Types;

public class InputMediaAudioForUpload : InputMediaDocumentForUpload
{
    public InputMediaAudioForUpload(
        FileInfo file,
        FileInfo? thumbnailFile = null,
        string? caption = null,
        string? title = null
    )
        : base(file, thumbnailFile, caption)
    {
        Type = "audio";
        Title = title;
    }
}

public class InputMediaAudioForFileIdOrUrl : InputMediaDocumentForFileIdOrUrl
{
    public InputMediaAudioForFileIdOrUrl(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null,
        string? title = null
    )
        : base(fileIdOrUrl, thumbnailFileIdOrUrl, caption)
    {
        Type = "audio";
        Title = title;
    }
}
