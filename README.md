[این را به فارسی بخوانید (Persian)](README.fa.md)

# BaleBotNet

A .NET library for interacting with the Bale Messenger Bot API.

[Subscribe us in Bale](https://ble.ir/BaleBotNet)

[BaleBotNet Nuget](https://www.nuget.org/packages/BaleBotNet)

## Installation

To use `BaleBotNet` in your project, add the NuGet package:

```bash
dotnet add package BaleBotNet
```

Or, in the NuGet Package Manager Console:

```bash
Install-Package BaleBotNet
```

## Usage in ASP.NET Core Projects

### Step 1: Add BaleBotClient to the Service Container

In your Program.cs, use the AddBaleBotClient extension method to register the BaleBotClient:

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add BaleBotClient to the service container
builder.Services.AddBaleBotClient("YOUR_BOT_TOKEN");

var app = builder.Build();
```

### Step 2: Map the Webhook

Use the MapBaleBotWebhook extension method to configure the webhook endpoint. You can handle different types of updates (e.g., messages, edited messages, callback queries, etc.).

#### Example 1: Handling Specific Update Types

```csharp
app.MapBaleBotWebhook(
    appBaseUrl: "https://yourdomain.com",
    handleMessage: async (message) =>
    {
        Console.WriteLine($"Received message: {message.Text}");
    },
    handleEditedMessage: async (editedMessage) =>
    {
        Console.WriteLine($"Edited message: {editedMessage.Text}");
    },
    handleCallbackQuery: async (callbackQuery) =>
    {
        Console.WriteLine($"Callback query: {callbackQuery.Data}");
    },
    handlePreCheckoutQuery: async (preCheckoutQuery) =>
    {
        Console.WriteLine($"Pre-checkout query: {preCheckoutQuery.InvoicePayload}");
    }
);
```

#### Example 2: Handling All Updates in a Single Function

```csharp
app.MapBaleBotWebhook(
    appBaseUrl: "https://yourdomain.com",
    handleUpdate: async (update) =>
    {
        switch (update)
        {
            case { Message: { } message }:
                Console.WriteLine($"Received message: {message.Text}");
                break;
            case { EditedMessage: { } editedMessage }:
                Console.WriteLine($"Edited message: {editedMessage.Text}");
                break;
            case { CallbackQuery: { } callbackQuery }:
                Console.WriteLine($"Callback query: {callbackQuery.Data}");
                break;
            case { PreCheckoutQuery: { } preCheckoutQuery }:
                Console.WriteLine($"Pre-checkout query: {preCheckoutQuery.InvoicePayload}");
                break;
            default:
                Console.WriteLine("Unknown update type.");
                break;
        }
    }
);
```

### Step 3: Run the Application

Run your application, and the webhook will be automatically set up with a unique path. The bot will start receiving updates at the configured endpoint.

```csharp
app.Run();
```

### Work with Methods

```csharp
var me = await bot.GetMe();

var message = await bot.SendMessage("123", $"Hi! I'm @{me.Username} !");

message = await bot.SendMessage(
    chatId: "123",
    text: "Hello, World! Reply with InlineKeyboardMarkup",
    replyToMessageId: firstMessageId,
    replyMarkup: new InlineKeyboardMarkup
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
```

There are lot of Samples at [Sample Project](https://github.com/RavaqeMehr/BaleBotNet/blob/main/Sample/Program.cs)
