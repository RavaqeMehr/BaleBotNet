using BaleBot.Net.Types;

namespace BaleBot.Net;

public enum ChatAction
{
    Typing,
    UploadPhoto,
    UploadVideo,
    UploadVoice,
}

public enum ChatType
{
    Private,
    Group,
    Channel
}

public static class EnumsExtentions
{
    public static string Serialize(this ChatAction action) =>
        action switch
        {
            ChatAction.UploadPhoto => "upload_photo",
            ChatAction.UploadVideo => "upload_video",
            ChatAction.UploadVoice => "upload_voice",
            _ => "typing"
        };

    public static ChatType GetType(this Chat chat) =>
        chat.Type switch
        {
            "private" => ChatType.Private,
            "group" => ChatType.Group,
            "channel" => ChatType.Channel,
            _ => throw new ArgumentOutOfRangeException(nameof(chat.Type), chat.Type, null)
        };
}
