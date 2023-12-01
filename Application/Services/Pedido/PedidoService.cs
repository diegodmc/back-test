public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IItensPedidoRepository _itensPedidoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly global::AutoMapper.IMapper _mapper;
    public PedidoService(IPedidoRepository pedidoRepository, IItensPedidoRepository itensPedidoRepository, IProdutoRepository produtoRepository, global::AutoMapper.IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _itensPedidoRepository = itensPedidoRepository;
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<List<Pedido>> ObterTodosPedidos()
    {
        return await _pedidoRepository.ObterTodosPedidos();
    }

    public async Task<PedidoResponse> ObterPedidoResponsePorId(int id)
    {
        var pedido = await _pedidoRepository.ObterPedidoPorId(id);
        var itensPedido = _itensPedidoRepository.ObterItensPedidoPorId(id);

        PedidoResponse pedidoResponse = await Task.Run(() =>
         {
             return _mapper.Map<PedidoResponse>(pedido);
         });

        List<ItensPedidoDTO> itensPedidoDTO = await Task.Run(() =>
         {
             return _mapper.Map<List<ItensPedidoDTO>>(itensPedido);
         });
        decimal valorTotal = 0;
        foreach (var item in itensPedidoDTO)
        {
            var produto = _produtoRepository.ObterProdutoPorId(item.IdProduto).Result;
            valorTotal = valorTotal + (item.Quantidade * produto.Valor);
            item.ValorUnitario = produto.Valor;
            item.NomeProduto = produto.NomeProduto;
        }

        pedidoResponse.ItensPedido = itensPedidoDTO;
        pedidoResponse.ValorTotal = valorTotal;
        return pedidoResponse;
    }

    public async Task<Pedido> ObterPedidoPorId(int id)
    {
        return await _pedidoRepository.ObterPedidoPorId(id);
    }

    public async Task<Pedido> ObterPedidoPorNomeCliente(string nome)
    {
        return await _pedidoRepository.ObterPedidoPorNomeCliente(nome);
    }
    public async Task InserirPedido(PedidoDTO pedidoDTO)
    {
        Pedido pedido = await Task.Run(() =>
        {
            return _mapper.Map<Pedido>(pedidoDTO);
        });

        pedido.DataCriacao = DateTime.Now;

        var pedidoDB = await _pedidoRepository.InserirPedido(pedido);

        List<ItensPedido> itensPedido = await Task.Run(() =>
         {
             return _mapper.Map<List<ItensPedido>>(pedidoDTO.ItensPedidos);
         });

        foreach (var itens in itensPedido)
        {
            itens.PedidoId = pedidoDB.Id;
            await _itensPedidoRepository.InserirItensPedido(itens);
        }
    }

    public async Task AtualizarPedido(Pedido pedido, List<ItensPedidoDTO> itensPedidoDTO)
    {
        foreach (var item in itensPedidoDTO)
        {
            ItensPedido itensPedido = await Task.Run(() =>
            {
                return _mapper.Map<ItensPedido>(item);
            });

            itensPedido.PedidoId = pedido.Id;
            await _itensPedidoRepository.AtualizarItensPedido(itensPedido);
            await _produtoRepository.AtualizarProduto(new Produto(){ Id = item.IdProduto, Valor = item.ValorUnitario, NomeProduto = item.NomeProduto});
        }
        await _pedidoRepository.AtualizarPedido(pedido);
    }

    public async Task<bool> ExcluirPedido(int id)
    {
        return await _pedidoRepository.ExcluirPedido(id);
    }
}