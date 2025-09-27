using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<string> CreateInvoiceLink(
        this BaleBotClient bot,
        string title,
        string description,
        string payload,
        string providerToken,
        LabeledPrice[] prices
    ) =>
        await bot.SendRequest<string>(
            BotRequest.CreatePost(
                "createInvoiceLink",
                new
                {
                    title,
                    description,
                    payload,
                    providerToken,
                    prices
                }
            )
        );
}
