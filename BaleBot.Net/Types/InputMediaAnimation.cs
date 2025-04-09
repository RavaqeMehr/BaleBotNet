namespace BaleBot.Net.Types;

public class InputMediaAnimation : InputMediaDocument
{
    public InputMediaAnimation(
        string fileIdOrUrl,
        string? thumbnailFileIdOrUrl = null,
        string? caption = null
    )
        : base(fileIdOrUrl, thumbnailFileIdOrUrl, caption)
    {
        Type = "animation";
    }

    public InputMediaAnimation(
        FileInfo file,
        FileInfo? thumbnailFile = null,
        string? caption = null
    )
        : base(file, thumbnailFile, caption)
    {
        Type = "animation";
    }
}
