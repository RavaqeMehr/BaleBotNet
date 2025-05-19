namespace BaleBotNet.Types;

public class Contact
{
    public string PhoneNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }
    public long? UserId { get; set; }
}
