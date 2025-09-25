#:property PublishAot=false
#:package BaleBotNet@2.1.1

using BaleBotNet;
using BaleBotNet.Enums;
using BaleBotNet.Methods;

BaleBotClient bot = new("bot-token");
int? offset = null;

do
{
    var updates = await bot.GetUpdates(offset, 10);

    var tasks = updates?
        .Where(update => update.Message?.Chat.Type == ChatType.Private)
        .Select(update => update.Message!)
        .Select(message => message.CopyTo(bot, message.Chat.Id))
        .ToList();

    if (tasks?.Count > 0)
        await Task.WhenAll(tasks);

    if (updates?.Length > 0)
        offset = updates?.Last().UpdateId + 1;

    await Task.Delay(1000);

} while (true);

