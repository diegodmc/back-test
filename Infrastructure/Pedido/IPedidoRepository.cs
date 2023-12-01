public interface IPedidoRepository
{
    Task<List<Pedido>> ObterTodosPedidos();
    Task<Pedido> ObterPedidoPorId(int id);
    Task<Pedido> InserirPedido(Pedido pedido);
    Task AtualizarPedido(Pedido pedido);
    Task<bool> ExcluirPedido(int id);
    Task<Pedido> ObterPedidoPorNomeCliente(string nome);
}