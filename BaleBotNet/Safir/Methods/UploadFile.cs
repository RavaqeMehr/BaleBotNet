using BaleBotNet.Safir.Types;

namespace BaleBotNet.Safir;

public static partial class Methods
{
    public static async Task<UploadFileResult> UploadFile(this SafirClient safir, FileInfo fileInfo)
    {
        using FileStream fileStream = new(fileInfo.FullName, FileMode.Open, FileAccess.Read);
        using StreamContent fileContent = new(fileStream);
        using MultipartFormDataContent file = new() { { fileContent, "file" } };

        return await safir.SendRequest<UploadFileResult>(
            BotRequest.CreateForm("upload_file", file)
        );
    }
}
