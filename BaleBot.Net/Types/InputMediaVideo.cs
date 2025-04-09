namespace BaleBot.Net.Types;

public class InputMediaVideo : InputMediaDocument
{
    public InputMediaVideo(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null
    )
        : base(fileIdOrUrl, thumbnailFileIdOrUrl, caption)
    {
        Type = "video";
    }

    public InputMediaVideo(FileInfo file, FileInfo? thumbnailFile = null, string? caption = null)
        : base(file, thumbnailFile, caption)
    {
        Type = "video";
    }
}
