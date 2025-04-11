namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SendChatAction(
        this BaleBotClient bot,
        long chatId,
        ChatAction action
    )
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"sendChatAction?chat_id={chatId}&action={action.Serialize()}"
        );

        return await bot.SendRequest<bool>(request);
    }
}
