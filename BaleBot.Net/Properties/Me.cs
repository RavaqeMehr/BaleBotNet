using BaleBot.Net.Methods;
using BaleBot.Net.Types;

namespace BaleBot.Net;

public partial class BaleBotClient
{
    private User? _Me;

    public User UpdateMe()
    {
        _Me = this.GetMe().Result;
        return _Me;
    }

    public User Me
    {
        get => _Me ?? UpdateMe();
    }
}
