using System.Text.Json.Serialization;

namespace BaleBotNet.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionStatus
{
    Pending,
    Succeed,
    Failed,
    Rejected,
    Timeout
}
