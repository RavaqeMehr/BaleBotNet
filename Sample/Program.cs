using System.Text.Json;
using BaleBot.Net;
using BaleBot.Net.Methods;
using BaleBot.Net.Types;

var env =
    JsonSerializer.Deserialize<Env>(await System.IO.File.ReadAllTextAsync("env.json"))
    ?? throw new Exception("Failed to load env.json file.");

var bot = new BaleBotClient(env.Token);

var me = await bot.GetMe();
Message message;

message = await bot.SendMessage(env.TestChatId, $"Hi! I'm @{me.Username} !");
Console.WriteLine($"Message Sent: {message.MessageId}");
var firstMessageId = message.MessageId;

#region Send, Edit & Delete Message
// message = await bot.SendMessage(
//     env.TestChatId,
//     "Hello, World! Reply with InlineKeyboardMarkup",
//     firstMessageId,
//     new InlineKeyboardMarkup
//     {
//         InlineKeyboard =
//         [
//             [
//                 new() { Text = "Text1", CallbackData = "test1" },
//                 new() { Text = "Text2", CallbackData = "test2" }
//             ]
//         ]
//     }
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendMessage(
//     env.TestChatId,
//     "Hello, World! Reply with ReplyKeyboardMarkup",
//     firstMessageId,
//     new ReplyKeyboardMarkup
//     {
//         Keyboard =
//         [
//             [new() { Text = "Text1" }, new() { Text = "Text2" }]
//         ]
//     }
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.ForwardMessage(env.TestChatId, env.TestChatId, firstMessageId);
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendMessage(env.TestChatId, "Clean Reply Markup!");
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.CopyMessage(message.Chat.Id, message.Chat.Id, message.MessageId);
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.EditMessage(env.TestChatId, firstMessageId, "Hello, World! Edited!");
// Console.WriteLine($"Message Edited: {message.MessageId}");

// var deleted = await bot.DeleteMessage(env.TestChatId, firstMessageId);
// Console.WriteLine($"Message Deleted: {deleted}");
#endregion

#region Send Photo
// message = await bot.SendPhoto(
//     env.TestChatId,
//     "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/PNG_transparency_demonstration_1.png/800px-PNG_transparency_demonstration_1.png",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendPhoto(
//     env.TestChatId,
//     "948302853:-2130208011622211839:1:a6be9173b0d1d688d7c2f54fcdd42a151a9ec6f7595b78a8",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendPhoto(
//     env.TestChatId,
//     new FileInfo(@"assets\bale.webp"),
//     fileName: "بله.webp",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Audio
// message = await bot.SendAudio(
//     env.TestChatId,
//     "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendAudio(
//     env.TestChatId,
//     "1562583495:6023008542197686018:1:e854097b7f467a4695109c46edfc75cd",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendAudio(
//     env.TestChatId,
//     new FileInfo(@"assets\esfahani.mp3"),
//     fileName: "اصفهانی.mp3",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion
