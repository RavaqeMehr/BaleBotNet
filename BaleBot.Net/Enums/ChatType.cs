using BaleBot.Net.Types;

namespace BaleBot.Net.Enums;

public enum ChatType
{
    Private,
    Group,
    Channel
}

public static class ChatTypeExtentions
{
    public static ChatType GetChatType(this Chat chat) =>
        chat.Type switch
        {
            "private" => ChatType.Private,
            "group" => ChatType.Group,
            "channel" => ChatType.Channel,
            _ => throw new ArgumentOutOfRangeException(nameof(chat.Type), chat.Type, null)
        };
}
