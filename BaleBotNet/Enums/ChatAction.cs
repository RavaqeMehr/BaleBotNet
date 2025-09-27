namespace BaleBotNet.Enums;

public enum ChatAction
{
    Typing,
    UploadPhoto,
    RecordVideo,
    UploadVideo,
    RecordVoice,
    UploadVoice,
    ChooseSticker,
}

public static class ChatActionExtentions
{
    public static string Serialize(this ChatAction action) =>
        action switch
        {
            ChatAction.UploadPhoto => "upload_photo",
            ChatAction.RecordVideo => "record_video",
            ChatAction.UploadVideo => "upload_video",
            ChatAction.RecordVoice => "record_voice",
            ChatAction.UploadVoice => "upload_voice",
            ChatAction.ChooseSticker => "choose_sticker",
            _ => "typing"
        };
}
