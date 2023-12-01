using System.Net;
using FastEndpoints;
public class ProdutoGetAll : EndpointWithoutRequest<List<Produto>>
{
    private readonly IProdutoService _produtoService;
    public ProdutoGetAll(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }
    public override void Configure()
    {
        Get("/api/product-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var produto = await _produtoService.ObterTodosProdutos();

        if (produto == null)
        {
            await SendAsync(null,
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        await SendAsync(produto);
    }
}
