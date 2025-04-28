using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BaleBot.Net.Types
{
    [JsonConverter(typeof(ChatIdConverter))]
    public class ChatId
    {
        public long? NumericId { get; set; } = null;
        public string? Username { get; set; } = null;

        public ChatId(long numericId)
        {
            NumericId = numericId;
        }

        public ChatId(string userName)
        {
            if (
                long.TryParse(
                    userName,
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out long numericId
                )
            )
            {
                NumericId = numericId;
            }
            else if (!userName.StartsWith('@'))
            {
                Username = $"@{userName}";
            }
            else
            {
                Username = userName;
            }
        }

        public override string ToString() =>
            (Username ?? NumericId?.ToString(CultureInfo.InvariantCulture))!;

        public static implicit operator ChatId(long numericId) => new(numericId);

        public static implicit operator ChatId(string userName) => new(userName);

        public static implicit operator ChatId?(Chat? chat) => chat == null ? null : new(chat.Id);

        public static bool operator ==(ChatId? obj1, ChatId? obj2)
        {
            if (obj1 is null || obj2 is null)
                return false;
            if (obj1.NumericId is not null && obj2.NumericId is not null)
                return obj1.NumericId == obj2.NumericId;
            if (obj1.Username is not null && obj2.Username is not null)
                return string.Equals(
                    obj1.Username,
                    obj2.Username,
                    StringComparison.OrdinalIgnoreCase
                );
            return false;
        }

        public static bool operator !=(ChatId obj1, ChatId obj2) => !(obj1 == obj2);

        public override bool Equals(object? obj) => obj is ChatId chatId && this == chatId;

        public bool Equals(ChatId? other) => this == other;

        public override int GetHashCode() =>
            StringComparer.InvariantCulture.GetHashCode(ToString());
    }

    internal sealed class ChatIdConverter : JsonConverter<ChatId?>
    {
        public override ChatId? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        ) =>
            JsonElement.TryParseValue(ref reader, out var element)
                ? new(element.Value.ToString())
                : null;

        public override void Write(
            Utf8JsonWriter writer,
            ChatId? value,
            JsonSerializerOptions options
        )
        {
            switch (value)
            {
                case { Username: { } username }:
                    writer.WriteStringValue(username);
                    break;
                case { NumericId: { } numericId }:
                    writer.WriteNumberValue(numericId);
                    break;
                case null:
                    writer.WriteNullValue();
                    break;
                default:
                    throw new JsonException("Chat ID value is incorrect");
            }
        }
    }
}
