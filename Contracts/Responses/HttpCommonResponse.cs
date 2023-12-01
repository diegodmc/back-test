using System.Net;


public class HttpCommonResponse
{
    public HttpCommonResponse(HttpStatusCode statusCode, string type, string message)
    {
        StatusCode = (int)statusCode;
        Type = type;
        Message = message;
    }

    public HttpCommonResponse()
    {
    }

    public int StatusCode { get; set; }

    public string? Type { get; set; }

    public string? Message { get; set; }

    public bool MessageTypeIsSuccess()
    {
        return Type == HttpCommonResponseType.Success;
    }
}
