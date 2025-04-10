namespace BaleBot.Net.Types;

public class InputMediaPhoto : InputMedia
{
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
        FileInfo = file;
    }
}
