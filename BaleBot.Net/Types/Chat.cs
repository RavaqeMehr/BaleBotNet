namespace BaleBot.Net.Types;

public class Chat
{
    public long Id { get; set; }
    public string Type { get; set; } = default!;
    public string? Title { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public ChatPhoto? ChatPhoto { get; set; }
    public string? InviteLink { get; set; }
}
