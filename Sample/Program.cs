using System.Text.Json;
using BaleBot.Net;
using BaleBot.Net.Methods;
using BaleBot.Net.Types;

var env =
    JsonSerializer.Deserialize<Env>(await System.IO.File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

var bot = new BaleBotClient(env.Token);

var me = await bot.GetMe();
Console.WriteLine($"Hello, BaleBot.Net! I'm @{me.Username} !");

var message = await bot.SendMessage(env.TestChatId, "Hello, World!");
Console.WriteLine($"Message Sent: {message.MessageId}");
var firstMessageId = message.MessageId;

message = await bot.SendMessage(
    env.TestChatId,
    "Hello, World! Reply with InlineKeyboardMarkup",
    firstMessageId,
    new InlineKeyboardMarkup
    {
        InlineKeyboard =
        [
            [
                new() { Text = "Text1", CallbackData = "test1" },
                new() { Text = "Text2", CallbackData = "test2" }
            ]
        ]
    }
);
Console.WriteLine($"Message Sent: {message.MessageId}");

message = await bot.SendMessage(
    env.TestChatId,
    "Hello, World! Reply with ReplyKeyboardMarkup",
    firstMessageId,
    new ReplyKeyboardMarkup
    {
        Keyboard =
        [
            [new() { Text = "Text1" }, new() { Text = "Text2" }]
        ]
    }
);
Console.WriteLine($"Message Sent: {message.MessageId}");

message = await bot.ForwardMessage(env.TestChatId, env.TestChatId, firstMessageId);
Console.WriteLine($"Message Sent: {message.MessageId}");

message = await bot.SendMessage(env.TestChatId, "Clean Reply Markup!");
Console.WriteLine($"Message Sent: {message.MessageId}");
