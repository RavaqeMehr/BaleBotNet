namespace BaleBot.Net;

public enum ChatAction
{
    Typing,
    UploadPhoto,
    UploadVideo,
    UploadVoice,

    // UploadAudio,
    // UploadDocument,
    // RecordVideo,
    // RecordAudio,
    // RecordVoice,
    // FindLocation,
    // CancelLocation
}

public static class EnumsExtentions
{
    public static string Serialize(this ChatAction action) =>
        action switch
        {
            ChatAction.UploadPhoto => "upload_photo",
            ChatAction.UploadVideo => "upload_video",
            ChatAction.UploadVoice => "upload_voice",
            // ChatAction.UploadAudio => "upload_audio",
            // ChatAction.UploadDocument => "upload_document",
            // ChatAction.RecordVideo => "record_video",
            // ChatAction.RecordAudio => "record_audio",
            // ChatAction.RecordVoice => "record_voice",
            // ChatAction.FindLocation => "find_location",
            // ChatAction.CancelLocation => "cancel_location",
            // ChatAction.Typing => "typing",
            _ => "typing"
        };
}
