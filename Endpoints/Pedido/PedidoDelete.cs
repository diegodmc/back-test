using System.Net;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
public class PedidoDelete : Endpoint<BaseRequest, HttpCommonResponse>
{
    private readonly IPedidoService _pedidoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public PedidoDelete(IPedidoService pedidoService, global::AutoMapper.IMapper mapper)
    {
        _pedidoService = pedidoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Delete("/api/order/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync([FromRoute] BaseRequest req, CancellationToken ct)
    {
        var result = await _pedidoService.ExcluirPedido(req.Id);
        if (!result)
        {
            await SendAsync(new HttpCommonResponse(HttpStatusCode.NoContent, HttpCommonResponseType.Success, "NoContent"),
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        await SendAsync(new HttpCommonResponse(HttpStatusCode.OK, HttpCommonResponseType.Success, "Delete"),
                (int)HttpStatusCode.OK, ct);
    }
}
