namespace BaleBotNet.Types;

public class WebAppUser
{
    public long Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string? Username { get; set; }
    public string? LastName { get; set; }
    public bool AllowsWriteToPm { get; set; }
    public string? PhotoUrl { get; set; }
}
