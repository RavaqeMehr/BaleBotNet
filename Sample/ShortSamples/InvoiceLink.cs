using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task CreateInvoiceLink()
    {
        Console.WriteLine(
            await bot.CreateInvoiceLink(
                title: "تست صورت‌حساب",
                description: "آزمایشی",
                payload: "test-invocie-000",
                providerToken: "WALLET-TEST-1111111111111111",
                prices: [new LabeledPrice { Amount = 100000, Label = "محصول" }]
            )
        );
    }
}
