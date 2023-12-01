public class ItensPedidoService : IItensPedidoService
{
    private readonly IItensPedidoRepository _itensPedidoRepository;
    private readonly global::AutoMapper.IMapper _mapper;
    public ItensPedidoService(IItensPedidoRepository itensPedidoRepository, global::AutoMapper.IMapper mapper)
    {
        _itensPedidoRepository = itensPedidoRepository;
        _mapper = mapper;
    }

    public async Task<List<ItensPedido>> ObterTodosItensPedidos()
    {
        return await _itensPedidoRepository.ObterTodosItensPedidos();
    }

    public async Task<List<ItensPedido>> ObterItensPedidoPorIdPedido(int id)
    {
        return await _itensPedidoRepository.ObterItensPedidoPorId(id);
    }

    public async Task InserirItensPedido(ItensPedido itensPedido)
    {
        await _itensPedidoRepository.InserirItensPedido(itensPedido);
    }

    public async Task AtualizarItensPedido(ItensPedidoDTO itensPedidoDTO)
    {
        ItensPedido itensPedido = await Task.Run(() =>
       {
           return _mapper.Map<ItensPedido>(itensPedidoDTO);
       });
        await _itensPedidoRepository.AtualizarItensPedido(itensPedido);
    }

    public async Task ExcluirItensPedido(int id)
    {
        await _itensPedidoRepository.ExcluirItensPedido(id);
    }
}