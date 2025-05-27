using TransactionStatus = BaleBotNet.Enums.TransactionStatus;

namespace BaleBotNet.Types;

public class Transaction
{
    public string Id { get; set; } = default!;
    public TransactionStatus Status { get; set; }
    public long UserId { get; set; }
    public long Amount { get; set; }
    public int CreatedAt { get; set; }
}
