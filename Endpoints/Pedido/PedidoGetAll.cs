using System.Net;
using FastEndpoints;
public class PedidoGetAll : EndpointWithoutRequest<List<Pedido>>
{
    private readonly IPedidoService _pedidoService;
    
    public PedidoGetAll(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }
    public override void Configure()
    {
        Get("/api/pedido-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var pedido = await _pedidoService.ObterTodosPedidos();

        if (pedido == null)
        {
            await SendAsync(null,
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        await SendAsync(pedido);
    }
}
