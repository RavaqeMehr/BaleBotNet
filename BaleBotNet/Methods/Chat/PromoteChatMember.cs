using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> PromoteChatMember(
        this BaleBotClient bot,
        ChatId chatId,
        long userId,
        bool? canChangeInfo = null,
        bool? canPostMessages = null,
        bool? canEditMessages = null,
        bool? canDeleteMessages = null,
        bool? canManageVideoChats = null,
        bool? canInviteUsers = null,
        bool? canRestrictMembers = null
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost(
                "promoteChatMember",
                new
                {
                    chatId,
                    userId,
                    canChangeInfo,
                    canPostMessages,
                    canEditMessages,
                    canDeleteMessages,
                    canManageVideoChats,
                    canInviteUsers,
                    canRestrictMembers
                }
            )
        );

    public static async Task<bool> PromoteChatMemberWithAllAccess(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    ) => await bot.PromoteChatMember(chatId, userId, true, true, true, true, true, true, true);

    public static async Task<bool> PromoteChatMemberWithNoAccess(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    ) =>
        await bot.PromoteChatMember(
            chatId,
            userId,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        );
}
