[(English) Read this in English](README.md)

# BaleBotNet

یک کتابخانه دات نت برای ارتباط با API ربات پیام‌رسان بله.

[در کانال ما در بله از آخرین تغییرات مطلع باشید](https://ble.ir/BaleBotNet)

[نصب از نیوگت BaleBotNet](https://www.nuget.org/packages/BaleBotNet)

## نصب

برای استفاده از `BaleBotNet` در پروژه خود، بسته نیوگت را اضافه کنید:

```bash
dotnet add package BaleBotNet
```

یا در کنسول مدیریت بسته نیوگت:

```bash
Install-Package BaleBotNet
```

## استفاده در پروژه‌های ASP.NET Core

### مرحله ۱: افزودن BaleBotClient به Service Container

در فایل Program.cs، از متد تمدید AddBaleBotClient برای ثبت BaleBotClient استفاده کنید:

```csharp
var builder = WebApplication.CreateBuilder(args);

// اضافه کردن BaleBotClient به service container
builder.Services.AddBaleBotClient("YOUR_BOT_TOKEN");

var app = builder.Build();
```

### مرحله ۲: تنظیم Webhook

از متد تمدید MapBaleBotWebhook برای تنظیم نقطه پایانی webhook استفاده کنید. می‌توانید انواع مختلف به‌روزرسانی‌ها را مدیریت کنید (مانند پیام‌ها، پیام‌های ویرایش شده، پرس‌وجوهای callback و غیره).

#### مثال ۱: مدیریت انواع خاص به‌روزرسانی

```csharp
app.MapBaleBotWebhook(
    appBaseUrl: "https://yourdomain.com",
    handleMessage: async (message) =>
    {
        Console.WriteLine($"پیام دریافت شده: {message.Text}");
    },
    handleEditedMessage: async (editedMessage) =>
    {
        Console.WriteLine($"پیام ویرایش شده: {editedMessage.Text}");
    },
    handleCallbackQuery: async (callbackQuery) =>
    {
        Console.WriteLine($"پرس‌وجوی callback: {callbackQuery.Data}");
    },
    handlePreCheckoutQuery: async (preCheckoutQuery) =>
    {
        Console.WriteLine($"پرس‌وجوی pre-checkout: {preCheckoutQuery.InvoicePayload}");
    }
);
```

#### مثال ۲: مدیریت تمام به‌روزرسانی‌ها در یک تابع

```csharp
app.MapBaleBotWebhook(
    appBaseUrl: "https://yourdomain.com",
    handleUpdate: async (update) =>
    {
        switch (update)
        {
            case { Message: { } message }:
                Console.WriteLine($"پیام دریافت شده: {message.Text}");
                break;
            case { EditedMessage: { } editedMessage }:
                Console.WriteLine($"پیام ویرایش شده: {editedMessage.Text}");
                break;
            case { CallbackQuery: { } callbackQuery }:
                Console.WriteLine($"پرس‌وجوی callback: {callbackQuery.Data}");
                break;
            case { PreCheckoutQuery: { } preCheckoutQuery }:
                Console.WriteLine($"پرس‌وجوی pre-checkout: {preCheckoutQuery.InvoicePayload}");
                break;
            default:
                Console.WriteLine("نوع به‌روزرسانی ناشناخته.");
                break;
        }
    }
);
```

### مرحله ۳: اجرای برنامه

برنامه خود را اجرا کنید، و webhook به طور خودکار با یک مسیر منحصر به فرد تنظیم خواهد شد. ربات شروع به دریافت به‌روزرسانی‌ها در نقطه پایانی پیکربندی شده خواهد کرد.

```csharp
app.Run();
```

### کار با متدها

```csharp
var me = await bot.GetMe();

var message = await bot.SendMessage("123", $"سلام! من @{me.Username} هستم!");

message = await bot.SendMessage(
    chatId: "123",
    text: "سلام دنیا! پاسخ با InlineKeyboardMarkup",
    replyToMessageId: firstMessageId,
    replyMarkup: new InlineKeyboardMarkup
    {
        InlineKeyboard =
        [
            [
                new() { Text = "متن۱", CallbackData = "test1" },
                new() { Text = "متن۲", CallbackData = "test2" }
            ]
        ]
    }
);
Console.WriteLine($"پیام ارسال شد: {message.MessageId}");
```

نمونه‌های بیشتر در [پروژه نمونه](https://github.com/RavaqeMehr/BaleBotNet/blob/main/Sample/Program.cs) موجود است
