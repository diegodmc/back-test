using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

public class PedidoPut : Endpoint<PedidoRequest, HttpCommonResponse>
{
    private readonly IPedidoService _pedidoService;

    private readonly IItensPedidoService _itensPedidoService;
    private readonly global::AutoMapper.IMapper _mapper;

    public PedidoPut(IPedidoService pedidoService, IItensPedidoService itensPedidoService, global::AutoMapper.IMapper mapper)
    {
        _pedidoService = pedidoService;
        _itensPedidoService = itensPedidoService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Put("/api/order/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync([FromRoute] PedidoRequest req, CancellationToken ct)
    {
        var pedido = await _pedidoService.ObterPedidoPorId(req.Id);
        if (pedido == null)
        {
            await SendAsync(new HttpCommonResponse(),
                (int)HttpStatusCode.NoContent, ct);
            return;
        }
        
        pedido.NomeCliente = req.NomeCliente;
        pedido.EmailCliente = req.EmailCliente;
        pedido.Pago = req.Pago;
        
        await _pedidoService.AtualizarPedido(pedido, req.ItensPedidos);

        await SendAsync(new HttpCommonResponse(HttpStatusCode.OK, HttpCommonResponseType.Success, "Put"),
               (int)HttpStatusCode.OK, ct);
    }
}
