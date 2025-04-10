namespace BaleBot.Net.Types;

public class InputMediaAudio : InputMediaDocument
{
    public InputMediaAudio(
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

    public InputMediaAudio(
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
