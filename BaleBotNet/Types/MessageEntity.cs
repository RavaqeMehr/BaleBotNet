using BaleBotNet.Enums;

namespace BaleBotNet.Types;

public class MessageEntity
{
    public MessageEntityType Type { get; set; }
    public int Offset { get; set; }
    public int Length { get; set; }
    public string? Url { get; set; }
    public User? User { get; set; }
    public string? Language { get; set; }
    public string? CustomEmojiId { get; set; }
}
