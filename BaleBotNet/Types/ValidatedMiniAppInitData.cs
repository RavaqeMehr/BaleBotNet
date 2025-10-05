namespace BaleBotNet.Types;

public class ValidatedMiniAppInitData(Dictionary<string, string> fields)
{
    public int AuthDate { get; set; } = int.Parse(fields["auth_date"]);
    public string QueryId { get; set; } = fields["query_id"];
    public WebAppUser User { get; set; } =
        BaleBotNetJsonTools.DeserializeFromJson<WebAppUser>(fields["user"])!;
}
