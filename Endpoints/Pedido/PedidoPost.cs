using System.Net;
using FastEndpoints;
public class PedidoPost : Endpoint<PedidoRequest, HttpCommonResponse>
{
    private readonly IPedidoService _pedidoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public PedidoPost(IPedidoService pedidoService, global::AutoMapper.IMapper mapper)
    {
        _pedidoService = pedidoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Post("/api/order/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PedidoRequest req, CancellationToken ct)
    {
        PedidoDTO pedidoDTO = await Task.Run(() =>
       {
           return _mapper.Map<PedidoDTO>(req);
       });

        await _pedidoService.InserirPedido(pedidoDTO);

        await SendAsync(new HttpCommonResponse(HttpStatusCode.OK, HttpCommonResponseType.Success, "Post"),
              (int)HttpStatusCode.OK, ct);
    }
}
