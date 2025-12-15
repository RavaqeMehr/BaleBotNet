using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using BaleBotNet.Enums;

namespace BaleBotNet.Types;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "status")]
[JsonDerivedType(typeof(ChatMemberOwner), "creator")]
[JsonDerivedType(typeof(ChatMemberAdministrator), "administrator")]
[JsonDerivedType(typeof(ChatMemberMember), "member")]
[JsonDerivedType(typeof(ChatMemberRestricted), "restricted")]
public abstract class ChatMember
{
    [JsonIgnore]
    public abstract ChatMemberStatus Status { get; }
    public required User User { get; set; }

    public bool IsOwnerMember([NotNullWhen(true)] out ChatMemberOwner? chatMemberOwner)
    {
        if (Status == ChatMemberStatus.Creator)
        {
            chatMemberOwner = (ChatMemberOwner)this;
            return true;
        }

        chatMemberOwner = null;
        return false;
    }

    public bool IsAdministratorMember(
        [NotNullWhen(true)] out ChatMemberAdministrator? chatMemberAdministrator
    )
    {
        if (Status == ChatMemberStatus.Administrator)
        {
            chatMemberAdministrator = (ChatMemberAdministrator)this;
            return true;
        }

        chatMemberAdministrator = null;
        return false;
    }

    public bool IsMemberMember([NotNullWhen(true)] out ChatMemberMember? chatMemberMember)
    {
        if (Status == ChatMemberStatus.Member)
        {
            chatMemberMember = (ChatMemberMember)this;
            return true;
        }

        chatMemberMember = null;
        return false;
    }

    public bool IsRestrictedMember(
        [NotNullWhen(true)] out ChatMemberRestricted? chatMemberRestricted
    )
    {
        if (Status == ChatMemberStatus.Member)
        {
            chatMemberRestricted = (ChatMemberRestricted)this;
            return true;
        }

        chatMemberRestricted = null;
        return false;
    }
}

public class ChatMemberOwner : ChatMember
{
    [JsonIgnore]
    public override ChatMemberStatus Status => ChatMemberStatus.Creator;
    public bool IsAnonymous { get; set; }
}

public class ChatMemberAdministrator : ChatMember
{
    [JsonIgnore]
    public override ChatMemberStatus Status => ChatMemberStatus.Administrator;
    public bool IsAnonymous { get; set; }
    public bool CanDeleteMessages { get; set; }
    public bool CanManageVideoChats { get; set; }
    public bool CanRestrictMembers { get; set; }
    public bool CanPromoteMembers { get; set; }
    public bool CanChangeInfo { get; set; }
    public bool CanInviteUsers { get; set; }
    public bool CanPostStories { get; set; }
    public bool CanPostMessages { get; set; }
    public bool CanEditMessages { get; set; }
    public bool CanPinMessages { get; set; }
}

public class ChatMemberMember : ChatMember
{
    [JsonIgnore]
    public override ChatMemberStatus Status => ChatMemberStatus.Member;
}

public class ChatMemberRestricted : ChatMember
{
    [JsonIgnore]
    public override ChatMemberStatus Status => ChatMemberStatus.Restricted;
    public bool IsMember { get; set; }
    public bool CanSendMessages { get; set; }
    public bool CanSendAudios { get; set; }
    public bool CanSendDocuments { get; set; }
    public bool CanSendPhotos { get; set; }
    public bool CanSendVideos { get; set; }
    public bool CanChangeInfo { get; set; }
    public bool CanInviteUsers { get; set; }
    public bool CanPinMessages { get; set; }
}
