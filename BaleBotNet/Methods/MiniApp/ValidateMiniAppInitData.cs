using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static ValidatedMiniAppInitData ValidateMiniAppInitData(
        this BaleBotClient bot,
        string initData,
        int expireAfterMinutes
    )
    {
        bool loginWidget = false;

        var query = HttpUtility.ParseQueryString(initData ?? "");
        if (query.AllKeys.Where(x => x != null).Count() == 0)
        {
            var decoded = HttpUtility.UrlDecode(initData ?? "");
            query = HttpUtility.ParseQueryString(decoded ?? "");
        }

        var fields = query.AllKeys.ToDictionary(key => key!, key => query[key]!);

        var authDate = long.Parse(fields["auth_date"]);
        var nowUnix = (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
        var diff = TimeSpan.FromSeconds(nowUnix - authDate);
        if (diff > TimeSpan.FromMinutes(expireAfterMinutes))
        {
            throw new SecurityException("Data is expired!");
        }

        if (fields.Remove("hash", out var hash))
        {
            var dataCheckString = string.Join('\n', fields.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            var secretKey = loginWidget
                ? SHA256.HashData(Encoding.ASCII.GetBytes(bot.Token))
                : HMACSHA256.HashData(
                    Encoding.ASCII.GetBytes("WebAppData"),
                    Encoding.ASCII.GetBytes(bot.Token)
                );
            var computedHash = HMACSHA256.HashData(
                secretKey,
                Encoding.UTF8.GetBytes(dataCheckString)
            );

            if (computedHash.SequenceEqual(Convert.FromHexString(hash)))
                return new(fields);
        }
        throw new SecurityException("Invalid data hash!");
    }
}
