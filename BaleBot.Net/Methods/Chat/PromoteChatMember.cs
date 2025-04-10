using System.Net.Http.Json;

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
        var request = new HttpRequestMessage(HttpMethod.Post, "promoteChatMember")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    user_id = userId,
                    can_change_info = canChangeInfo,
                    can_post_messages = canPostMessages,
                    can_edit_messages = canEditMessages,
                    can_delete_messages = canDeleteMessages,
                    can_manage_video_chats = canManageVideoChats,
                    can_invite_users = canInviteUsers,
                    can_restrict_members = canRestrictMembers
                }
            )
        };

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> PromoteChatMemberWithAllAccess(
        this BaleBotClient bot,
        string chatId,
        long userId
    ) => await PromoteChatMember(bot, chatId, userId, true, true, true, true, true, true, true);

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
}
