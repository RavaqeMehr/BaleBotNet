namespace BaleBotNet.Enums;

public enum ChatAction
{
    Typing,
    UploadPhoto,
    UploadVideo,
    UploadVoice,
}

public static class ChatActionExtentions
{
    public static string Serialize(this ChatAction action) =>
        action switch
        {
            ChatAction.UploadPhoto => "upload_photo",
            ChatAction.UploadVideo => "upload_video",
            ChatAction.UploadVoice => "upload_voice",
            _ => "typing"
        };
}
