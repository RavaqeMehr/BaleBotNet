namespace BaleBot.Net.Types;

public class StickerSet
{
    public string Name { get; set; } = default!;
    public string Title { get; set; } = default!;
    public Sticker[] Stickers { get; set; } = default!;
    public PhotoSize? Thumbnail { get; set; }
}
