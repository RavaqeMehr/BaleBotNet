namespace BaleBotNet.Types;

public class Message
{
    public long MessageId { get; set; }
    public User? From { get; set; }
    public Chat? SenderChat { get; set; } // used in channel updates
    public int Date { get; set; }
    public Chat Chat { get; set; } = null!;
    public User? ForwardFrom { get; set; }
    public Chat? ForwardFromChat { get; set; }
    public long? ForwardFromMessageId { get; set; }
    public int? ForwardDate { get; set; }
    public Message? ReplyToMessage { get; set; }
    public int? EditDate { get; set; }
    public string? Text { get; set; }
    public MessageEntity[]? Entities { get; set; }
    public Animation? Animation { get; set; }
    public Audio? Audio { get; set; }
    public Document? Document { get; set; }
    public PhotoSize[]? Photo { get; set; }
    public Sticker? Sticker { get; set; }
    public Video? Video { get; set; }
    public Voice? Voice { get; set; }
    public string? Caption { get; set; }
    public MessageEntity[]? CaptionEntities { get; set; }
    public Contact? Contact { get; set; }
    public Location? Location { get; set; }
    public User[]? NewChatMembers { get; set; }
    public User? LeftChatMember { get; set; }
    public Invoice? Invoice { get; set; } // Not Found!!
    public SuccessfulPayment? SuccessfulPayment { get; set; }
    public WebAppData? WebAppData { get; set; }
    public InlineKeyboardMarkup? ReplyMarkup { get; set; }
}
