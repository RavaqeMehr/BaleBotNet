namespace BaleBot.Net.Types;

public abstract class InputMedia
{
    public string Type { get; set; } = default!;
    public FileInfo? FileInfo { get; set; }
    public string Media { get; set; } = default!;
    public string? Caption { get; set; }

    // For types: video, animation, audio, document
    public string? Thumbnail { get; set; }
    public FileInfo? ThumbnailFileInfo { get; set; }

    // Just Audi Type
    public string? Title { get; set; }
}

public class InputMediaMetaData
{
    public string Type { get; set; } = default!;
    public string Media { get; set; } = default!;
    public string? Caption { get; set; }
    public string? Thumbnail { get; set; }
    public string? Title { get; set; }
}

public static class InputMediaExtensions
{
    public static (
        MultipartFormDataContent multipartFormDataContent,
        InputMediaMetaData[] metaDatas
    ) GetMultipartFormDataContentAndMetaDatas(this InputMedia[] inputMedias)
    {
        var metaDatas = new List<InputMediaMetaData>();

        MultipartFormDataContent content = new();
        foreach (var item in inputMedias.Index())
        {
            var inputMedia = item.Item;
            var inputMediaNumber = item.Index + 1;

            InputMediaMetaData itemMetaData = new() { Type = inputMedia.Type };
            if (inputMedia.Caption is string caption && caption.Length > 0)
            {
                itemMetaData.Caption = caption;
            }
            if (inputMedia.Title is string title && title.Length > 0)
            {
                itemMetaData.Title = title;
            }

            if (inputMedia.FileInfo is FileInfo fileInfo)
            {
                FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read);
                var fileContent = new StreamContent(fileStream);
                string attachName = $"file{inputMediaNumber}";
                content.Add(fileContent, attachName, fileInfo.Name);
                itemMetaData.Media = $"<attach://{attachName}>";

                if (inputMedia.ThumbnailFileInfo is FileInfo thumbnailFileInfo)
                {
                    FileStream thumbnailStream =
                        new(thumbnailFileInfo.FullName, FileMode.Open, FileAccess.Read);
                    var thumbnailContent = new StreamContent(thumbnailStream);
                    string thumbAttachName = $"thumb{inputMediaNumber}";
                    content.Add(thumbnailContent, thumbAttachName, thumbnailFileInfo.Name);
                    itemMetaData.Thumbnail = $"<attach://{thumbAttachName}>";
                }
            }
            else
            {
                itemMetaData.Media = inputMedia.Media;

                if (!string.IsNullOrEmpty(inputMedia.Thumbnail))
                {
                    itemMetaData.Thumbnail = inputMedia.Thumbnail;
                }
            }

            metaDatas.Add(itemMetaData);
        }

        return (content, metaDatas.ToArray());
    }
}
