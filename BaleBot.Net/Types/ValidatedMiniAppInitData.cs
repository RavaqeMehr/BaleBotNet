namespace BaleBot.Net.Types;

public class ValidatedMiniAppInitData
{
    public int AuthDate { get; set; }
    public string QueryId { get; set; } = default!;
    public WebAppUser User { get; set; } = default!;
}
