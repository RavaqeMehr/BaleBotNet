using BaleBotNet;
using BaleBotNet.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task GetChatMember(long userId)
    {
        var chatId = 1234;
        var result = await bot.GetChatMember(chatId, userId);

        if (result.IsOwnerMember(out var owner))
            Console.WriteLine($"Owner: {BaleBotNetJsonTools.SerializeToJson(owner, true)}");

        if (result.IsAdministratorMember(out var administrator))
            Console.WriteLine(
                $"Administrator: {BaleBotNetJsonTools.SerializeToJson(administrator, true)}"
            );

        if (result.IsMemberMember(out var member))
            Console.WriteLine($"Member: {BaleBotNetJsonTools.SerializeToJson(member, true)}");

        if (result.IsRestrictedMember(out var restricted))
            Console.WriteLine(
                $"Restricted: {BaleBotNetJsonTools.SerializeToJson(restricted, true)}"
            );
    }
}
