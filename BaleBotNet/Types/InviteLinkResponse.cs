namespace BaleBotNet.Types;

public class InviteLinkResponse
{
    public string? InviteLink { get; set; }
    public User? Creator { get; set; }
    public bool? CreatesJoinRequest { get; set; }
    public bool? IsPrimary { get; set; }
    public bool? IsRevoked { get; set; }
    public string? Name { get; set; }
    public int? ExpireDate { get; set; }
    public int? MemberLimit { get; set; }
    public int? PendingJoinRequestCount { get; set; }
}
