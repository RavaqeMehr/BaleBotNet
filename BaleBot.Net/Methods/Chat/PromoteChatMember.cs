namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> PromoteChatMember(
        this BaleBotClient bot,
        string chatId,
        long userId,
        bool? canChangeInfo = null,
        bool? canPostMessages = null,
        bool? canEditMessages = null,
        bool? canDeleteMessages = null,
        bool? canManageVideoChats = null,
        bool? canInviteUsers = null,
        bool? canRestrictMembers = null
    )
    {
        var request = BotRequest.CreatePost(
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
        );

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> PromoteChatMember(
        this BaleBotClient bot,
        long chatId,
        long userId,
        bool? canChangeInfo = null,
        bool? canPostMessages = null,
        bool? canEditMessages = null,
        bool? canDeleteMessages = null,
        bool? canManageVideoChats = null,
        bool? canInviteUsers = null,
        bool? canRestrictMembers = null
    ) =>
        await PromoteChatMember(
            bot,
            chatId.ToString(),
            userId,
            canChangeInfo,
            canPostMessages,
            canEditMessages,
            canDeleteMessages,
            canManageVideoChats,
            canInviteUsers,
            canRestrictMembers
        );

    public static async Task<bool> PromoteChatMemberWithAllAccess(
        this BaleBotClient bot,
        string chatId,
        long userId
    ) => await PromoteChatMember(bot, chatId, userId, true, true, true, true, true, true, true);

    public static async Task<bool> PromoteChatMemberWithAllAccess(
        this BaleBotClient bot,
        long chatId,
        long userId
    ) => await PromoteChatMemberWithAllAccess(bot, chatId.ToString(), userId);

    public static async Task<bool> PromoteChatMemberWithNoAccess(
        this BaleBotClient bot,
        string chatId,
        long userId
    ) =>
        await PromoteChatMember(
            bot,
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

    public static async Task<bool> PromoteChatMemberWithNoAccess(
        this BaleBotClient bot,
        long chatId,
        long userId
    ) => await PromoteChatMemberWithNoAccess(bot, chatId.ToString(), userId);
}
