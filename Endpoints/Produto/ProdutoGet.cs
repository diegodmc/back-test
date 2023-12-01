using System.Net;
using FastEndpoints;
public class ProdutoGet : Endpoint<BaseRequest, ProdutoResponse>
{
    private readonly IProdutoService _produtoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public ProdutoGet(IProdutoService produtoService, global::AutoMapper.IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Get("/api/product");
        AllowAnonymous();
    }

    public override async Task HandleAsync(BaseRequest req, CancellationToken ct)
    {
        var produto = await _produtoService.ObterProdutoPorId(req.Id);

        if (produto == null)
        {
            await SendAsync(new ProdutoResponse(),
                (int)HttpStatusCode.NoContent, ct);
            return;
        }

        ProdutoResponse produtoResponse = await Task.Run(() =>
         {
             return _mapper.Map<ProdutoResponse>(produto);
         });

        await SendAsync(produtoResponse);
    }
}
