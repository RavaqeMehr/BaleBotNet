namespace BaleBotNet.Safir.Types;

public class TokenResult
{
    //Success
    public string? AccessToken { get; set; }

    public int? ExpiresIn { get; set; }

    public string? Scope { get; set; }

    public string? TokenType { get; set; }

    public bool IsSuccess() => AccessToken != null && AccessToken.Length > 0;

    //Error
    public string? Error { get; set; }
    public string? ErrorDescription { get; set; }

    //Server Error
    public int? Type { get; set; }
    public int? Code { get; set; }
    public string? Message { get; set; }
}

public class SendOtpResult
{
    public int? Balance { get; set; }

    public bool IsSuccess() => Balance != null;

    //Error
    public int? Type { get; set; }
    public int? Code { get; set; }
    public string? Message { get; set; }
}
