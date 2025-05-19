namespace BaleBotNet.Types;

public class Update
{
    public int UpdateId { get; set; }
    public Message? Message { get; set; }
    public Message? EditedMessage { get; set; }
    public CallbackQuery? CallbackQuery { get; set; }
    public PreCheckoutQuery? PreCheckoutQuery { get; set; }
}
