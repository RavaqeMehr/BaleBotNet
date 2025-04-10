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

#region Send Video
// message = await bot.SendVideo(
//     env.TestChatId,
//     "https://download.samplelib.com/mp4/sample-5s.mp4",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendVideo(
//     env.TestChatId,
//     "6313375308:-345340924282003710:1:ae6f9a208f138674e437abb5ef79a91267396412d657974b1c6a2f3cfa2833b7",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendVideo(
//     env.TestChatId,
//     new FileInfo(@"assets\video.mp4"),
//     fileName: "earth.mp4",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Document
// message = await bot.SendDocument(
//     env.TestChatId,
//     "https://www.nuget.org/profiles/RavaqeMehr/avatar?imageSize=512",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendDocument(
//     env.TestChatId,
//     "1562583495:6023008542197686018:1:e854097b7f467a4695109c46edfc75cd",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendDocument(
//     env.TestChatId,
//     new FileInfo(@"assets\sekke.jpg"),
//     fileName: "سکه.jpg",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Animation
// Has Errors
// message = await bot.SendAnimation(
//     env.TestChatId,
//     "https://novawebbusiness.com/wp-content/uploads/2022/12/Wow-gif.gif",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// Has Errors
// message = await bot.SendAnimation(
//     env.TestChatId,
//     "1559504661:-2250243873464180992:0:35157a1b7a3906da1a9ec6f7595b78a8",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendAnimation(
//     env.TestChatId,
//     new FileInfo(@"assets\cat.gif"),
//     fileName: "گربه.gif",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Voice
// message = await bot.SendVoice(
//     env.TestChatId,
//     "https://getsamplefiles.com/download/ogg/sample-1.ogg",
//     "send by url!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendVoice(
//     env.TestChatId,
//     "948302853:7993782975905799938:1:13cb8cee8a050f7fe83addac564f918d5c737303c407d73a540b672004186277bc72b9472207ef6e",
//     "send by fileId!",
//     firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendVoice(
//     env.TestChatId,
//     new FileInfo(@"assets\voice.opus"),
//     fileName: "سلام.opus",
//     caption: "uploaded by local file!",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Location
// message = await bot.SendLocation(
//     env.TestChatId,
//     35.9537207f,
//     52.109088f,
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendLocation(
//     env.TestChatId,
//     35.9537207f,
//     52.109088f,
//     horizontalAccuracy: 500,
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send Contact
// message = await bot.SendContact(
//     env.TestChatId,
//     "09876543210",
//     "Test local",
//     "Contact",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");

// message = await bot.SendContact(
//     env.TestChatId,
//     "+989876543210",
//     "Test +98",
//     replyToMessageId: firstMessageId
// );

// message = await bot.SendContact(
//     env.TestChatId,
//     "00989876543210",
//     "Test 0098",
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Message Sent: {message.MessageId}");
#endregion

#region Send MediaGroup
// Message[] album;

#region Photo
// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaPhotoForFileIdOrUrl(
//             "948302853:-2130208011622211839:1:a6be9173b0d1d688d7c2f54fcdd42a151a9ec6f7595b78a8",
//             caption: "send by fileId!"
//         ),
//         new InputMediaPhotoForFileIdOrUrl(
//             "https://upload.wikimedia.org/wikipedia/commons/thumb/4/47/PNG_transparency_demonstration_1.png/800px-PNG_transparency_demonstration_1.png",
//             caption: "send by url!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");

// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaPhotoForUpload(
//             new FileInfo(@"assets\bale.webp"),
//             caption: "uploaded1 by local file!"
//         ),
//         new InputMediaPhotoForUpload(
//             new FileInfo(@"assets\sekke.jpg"),
//             caption: "uploaded2 by local file!"
//         ),
//         new InputMediaPhotoForUpload(
//             new FileInfo(@"assets\cat.gif"),
//             caption: "uploaded3 by local file!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");
#endregion

#region Animation
// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaAnimationForFileIdOrUrl(
//             "1559504661:-2250243873464180992:0:35157a1b7a3906da1a9ec6f7595b78a8",
//             caption: "send by fileId!"
//         ),
//         new InputMediaAnimationForFileIdOrUrl(
//             "https://novawebbusiness.com/wp-content/uploads/2022/12/Wow-gif.gif",
//             caption: "send by url!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");

// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaAnimationForUpload(
//             new FileInfo(@"assets\cat.gif"),
//             caption: "uploaded1 by local file!"
//         ),
//         new InputMediaAnimationForUpload(
//             new FileInfo(@"assets\cat.gif"),
//             caption: "uploaded3 by local file!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");
#endregion

#region Video
// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaVideoForFileIdOrUrl(
//             "6313375308:-345340924282003710:1:ae6f9a208f138674e437abb5ef79a91267396412d657974b1c6a2f3cfa2833b7",
//             caption: "send by fileId!"
//         ),
//         new InputMediaVideoForFileIdOrUrl(
//             "https://download.samplelib.com/mp4/sample-5s.mp4",
//             caption: "send by url!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");

// album = await bot.SendMediaGroup(
//     env.TestChatId,
//     [
//         new InputMediaVideoForUpload(
//             new FileInfo(@"assets\video.mp4"),
//             caption: "uploaded1 by local file!"
//         ),
//         new InputMediaVideoForUpload(
//             new FileInfo(@"assets\video.mp4"),
//             caption: "uploaded2 by local file!"
//         )
//     ],
//     replyToMessageId: firstMessageId
// );
// Console.WriteLine($"Album Sent: {album.Length}");
#endregion

#endregion
