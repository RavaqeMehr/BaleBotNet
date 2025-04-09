namespace BaleBot.Net.Types;

public class CallbackQuery
{
    public string Id { get; set; } = default!;
    public User? From { get; set; }
    public Message? Message { get; set; }
    public string? Data { get; set; }
}
