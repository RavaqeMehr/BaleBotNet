namespace BaleBotNet.Types;

public class InputMediaPhotoForUpload : InputMediaForUpload
{
    public InputMediaPhotoForUpload(FileInfo file, string? caption = null)
    {
        Type = "photo";
        Caption = caption;
        FileInfo = file;
    }
}

public class InputMediaPhotoForFileIdOrUrl : InputMediaForFileIdOrUrl
{
    public InputMediaPhotoForFileIdOrUrl(string fileIdOrUrl, string? caption = null)
    {
        Type = "photo";
        Caption = caption;
        Media = fileIdOrUrl;
    }
}
