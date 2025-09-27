using BaleBotNet.Safir.Types;

namespace BaleBotNet.Safir;

public static partial class Methods
{
    public static async Task<SendMessageResult> SendMessage(
        this SafirClient safir,
        string? requestId,
        long botId,
        string phoneNumber,
        MessageData messageData
    ) =>
        await safir.SendRequest<SendMessageResult>(
            BotRequest.CreatePost(
                "send_message",
                new
                {
                    requestId,
                    botId,
                    phoneNumber,
                    messageData
                }
            )
        );
}
