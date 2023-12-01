public interface IPedidoService
{
    Task<List<Pedido>> ObterTodosPedidos();
    Task<PedidoResponse> ObterPedidoResponsePorId(int id);
    Task<Pedido> ObterPedidoPorId(int id);
    Task InserirPedido(PedidoDTO pedido);
    Task AtualizarPedido(Pedido pedido, List<ItensPedidoDTO> itensPedidoDTO);
    Task<bool> ExcluirPedido(int id);
    Task<Pedido> ObterPedidoPorNomeCliente(string nome);
}