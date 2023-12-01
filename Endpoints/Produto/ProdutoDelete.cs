using System.Net;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
public class ProdutoDelete : Endpoint<BaseRequest, HttpCommonResponse>
{
    private readonly IProdutoService _produtoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public ProdutoDelete(IProdutoService produtoService, global::AutoMapper.IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Delete("/api/product/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync([FromRoute] BaseRequest req, CancellationToken ct)
    {
        var result = await _produtoService.ExcluirProduto(req.Id);
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
