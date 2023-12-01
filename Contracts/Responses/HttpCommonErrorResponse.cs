using System.Net;


public class HttpCommonErrorResponse : HttpCommonResponse
{
    public HttpCommonErrorResponse(HttpStatusCode statusCode) : base(statusCode, "error", statusCode.ToString())
    {
    }

    public HttpCommonErrorResponse(HttpStatusCode statusCode, string message) : base(statusCode, "error", message)
    {
    }

    public HttpCommonErrorResponse(HttpStatusCode statusCode, string message, object? results) : this(statusCode,
        message)
    {
        Results = results;
    }

    public object? Results { get; set; }
}
