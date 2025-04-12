using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static ValidatedMiniAppInitData ValidateMiniAppInitData(
        this BaleBotClient bot,
        string initData
    )
    {
        bool loginWidget = false;
        // Console.WriteLine($"bot.Token:\n{bot.Token}\n");
        // Console.WriteLine($"initData:\n{initData}\n");

        var decoded = HttpUtility.UrlDecode(initData ?? "");
        // Console.WriteLine($"decoded:\n{decoded}\n");

        // var query = HttpUtility.ParseQueryString(decoded ?? "");
        var query = HttpUtility.ParseQueryString(initData ?? "");

        var fields = query.AllKeys.ToDictionary(key => key!, key => query[key]!);

        if (fields.Remove("hash", out var hash))
        {
            // Console.WriteLine($"hash:\n{hash}\n");

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

            // Console.WriteLine($"computedHash:\n{Convert.ToHexString(computedHash)}\n");

            if (computedHash.SequenceEqual(Convert.FromHexString(hash)))
                return new()
                {
                    QueryId = fields["query_id"],
                    AuthDate = int.Parse(fields["auth_date"]),
                    User = BaleBotClient.DeserializeFromJson<WebAppUser>(fields["user"])!,
                };
        }
        throw new SecurityException("Invalid data hash");
    }
}
