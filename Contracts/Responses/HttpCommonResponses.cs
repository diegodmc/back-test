using System.Net;


public static class HttpCommonResponses
{
    public static void BadRequest(Func<HttpCommonResponse, int, CancellationToken, Task> sendAsync, string message,
        CancellationToken ct)
    {
        sendAsync(new HttpCommonResponse(HttpStatusCode.BadRequest, HttpCommonResponseType.Error, message),
            (int)HttpStatusCode.BadRequest, ct).ConfigureAwait(false);
    }

    public static void EntityErrorConflict(Func<HttpCommonResponse, int, CancellationToken, Task> sendAsync,
        string message, CancellationToken ct)
    {
        sendAsync(new HttpCommonResponse(HttpStatusCode.Conflict, HttpCommonResponseType.Error, message),
            (int)HttpStatusCode.Conflict, ct).ConfigureAwait(false);
    }

    public static void CreateErrorResponse(Func<HttpCommonResponse, int, CancellationToken, Task> sendAsync,
        HttpStatusCode httpStatusCode, string message, CancellationToken ct)
    {
        sendAsync(new HttpCommonResponse(httpStatusCode, HttpCommonResponseType.Error, message),
            (int)httpStatusCode, ct).ConfigureAwait(false);
    }
}
