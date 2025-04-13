using BaleBot.Net.Types;

namespace BaleBot.Net;

public interface IUpdateHandler
{
    Task HandleUpdate(Update update, CancellationToken cancellationToken = default);
}

public interface IMessageUpdateHandler
{
    Task HandleUpdate(int updateId, Message message, CancellationToken cancellationToken = default);
}

public interface IEditedMessageUpdateHandler
{
    Task HandleUpdate(int updateId, Message message, CancellationToken cancellationToken = default);
}

public interface ICallbackQueryUpdateHandler
{
    Task HandleUpdate(
        int updateId,
        CallbackQuery callbackQuery,
        CancellationToken cancellationToken = default
    );
}

public interface IPreCheckoutQueryUpdateHandler
{
    Task HandleUpdate(
        int updateId,
        PreCheckoutQuery preCheckoutQuery,
        CancellationToken cancellationToken = default
    );
}
