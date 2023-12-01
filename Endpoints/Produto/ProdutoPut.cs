using System.Net;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

public class ProdutoPut : Endpoint<ProdutoRequest, ProdutoResponse>
{
    private readonly IProdutoService _produtoService;
    private readonly global::AutoMapper.IMapper _mapper;
    
    public ProdutoPut(IProdutoService produtoService, global::AutoMapper.IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Put("/api/product/{Id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync([FromRoute] ProdutoRequest req, CancellationToken ct)
    {
        var produto = await _produtoService.ObterProdutoPorId((int)req.Id);

        if (produto == null)
        {
            await SendAsync(new ProdutoResponse(),
                (int) HttpStatusCode.NoContent, ct);
            return;
        }
        
        produto.NomeProduto = req.NomeProduto;
        produto.Valor = req.Valor;

        await _produtoService.AtualizarProduto(produto);

        var respostaAtualizada = _mapper.Map<ProdutoResponse>(produto);
        
        await SendAsync(respostaAtualizada,
                (int) HttpStatusCode.OK, ct);
    }
}
