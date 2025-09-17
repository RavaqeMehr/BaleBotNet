namespace BaleBotNet.Types;

public class ReplyKeyboardRemove : IReplyMarkup
{
    public bool RemoveKeyboard { get; set; } = true;

    public override string ToString() => BaleBotClient.SerializeToJson(this)!;
}
