public interface IItensPedidoService
{
    Task<List<ItensPedido>> ObterTodosItensPedidos();
    Task<List<ItensPedido>> ObterItensPedidoPorIdPedido(int id);
    Task InserirItensPedido(ItensPedido itensPedido);
    Task AtualizarItensPedido(ItensPedidoDTO itensPedido);
    Task ExcluirItensPedido(int id);
}