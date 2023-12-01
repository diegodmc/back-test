using System.Net;
using FastEndpoints;

    public class GetEndpoint : EndpointWithoutRequest<HttpCommonResponse>
    {
        private const string Route = "/health-check";

        public override void Configure()
        {
            Get(Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendAsync(new HttpCommonResponse(HttpStatusCode.OK, HttpCommonResponseType.Success, "Healthy"),
                (int) HttpStatusCode.OK, ct);
        }
    }
