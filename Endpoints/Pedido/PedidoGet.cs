using System.Net;
using FastEndpoints;
public class PedidoGet : Endpoint<BaseRequest, PedidoResponse>
{
    private readonly IPedidoService _pedidoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public PedidoGet(IPedidoService pedidoService, global::AutoMapper.IMapper mapper)
    {
        _pedidoService = pedidoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Get("/api/order");
        AllowAnonymous();
    }

    public override async Task HandleAsync(BaseRequest req, CancellationToken ct)
    {
        var pedidoResponse = await _pedidoService.ObterPedidoResponsePorId(req.Id);

        if (pedidoResponse == null)
        {
            await SendAsync(new PedidoResponse(),
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        await SendAsync(pedidoResponse);
    }
}
