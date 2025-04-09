namespace BaleBot.Net.Types;

public class User
{
    public long Id { get; set; }
    public bool IsBot { get; set; }
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? LanguageCode { get; set; }
}
