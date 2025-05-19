using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaleBotNet.Types;

[JsonConverter(typeof(ReplyMarkupConverter))]
public interface IReplyMarkup
{
    string ToString();
}

public class ReplyMarkupConverter : JsonConverter<IReplyMarkup>
{
    public override IReplyMarkup Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        throw new NotImplementedException();
    }

    public override void Write(
        Utf8JsonWriter writer,
        IReplyMarkup value,
        JsonSerializerOptions options
    )
    {
        switch (value)
        {
            case null:
                JsonSerializer.Serialize(writer, (IReplyMarkup?)null, options);
                break;
            default:
            {
                var type = value.GetType();
                JsonSerializer.Serialize(writer, value, type, options);
                break;
            }
        }
    }
}

public static class ReplyKeyboard
{
    public static IReplyMarkup Clear() =>
        CreateKeyboard(
            [
                []
            ]
        );

    public static IReplyMarkup CreateKeyboard(KeyboardButton[][] buttons) =>
        new ReplyKeyboardMarkup { Keyboard = buttons };

    public static IReplyMarkup CreateInline(InlineKeyboardButton[][] buttons) =>
        new InlineKeyboardMarkup { InlineKeyboard = buttons };
}
