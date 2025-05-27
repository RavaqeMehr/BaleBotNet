using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task SendInvoice(long chatId)
    {
        await bot.SendInvoice(
            chatId: chatId,
            title: "تست صورت‌حساب",
            description: "آزمایشی",
            payload: "test-invocie-000",
            providerToken: "WALLET-TEST-1111111111111111",
            prices: [new LabeledPrice { Amount = 100000, Label = "محصول" }]
        );
    }

    public async Task InquireTransaction(string transactionId)
    {
        var result = await bot.InquireTransaction(transactionId);

        Console.WriteLine($"status: {result.Status}");
    }
}
