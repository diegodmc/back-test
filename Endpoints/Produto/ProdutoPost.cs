using System.Net;
using FastEndpoints;
public class ProdutoPost : Endpoint<ProdutoRequest, HttpCommonResponse>
{
    private readonly IProdutoService _produtoService;
    private readonly global::AutoMapper.IMapper _mapper;
    public ProdutoPost(IProdutoService produtoService, global::AutoMapper.IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }
    public override void Configure()
    {
        Post("/api/product/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ProdutoRequest req, CancellationToken ct)
    {
        Produto produto = await Task.Run(() =>
        {
            return _mapper.Map<Produto>(req);
        });

        await _produtoService.InserirProduto(produto);

        await SendAsync(new HttpCommonResponse(HttpStatusCode.OK, HttpCommonResponseType.Success, "Post"),
                (int) HttpStatusCode.OK, ct);
    }
}
