using System.Net;
using FastEndpoints;
public class PedidoGetByName : Endpoint<PedidoRequestByName, Pedido>
{
    private readonly IPedidoService _pedidoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public PedidoGetByName(IPedidoService pedidoService, global::AutoMapper.IMapper mapper)
    {
        _pedidoService = pedidoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Post("/api/get-by-name");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PedidoRequestByName req, CancellationToken ct)
    {
        var pedido = await _pedidoService.ObterPedidoPorNomeCliente(req.NomeCliente);

        if (pedido == null)
        {
            await SendAsync(null,
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        await SendAsync(pedido);
    }
}
