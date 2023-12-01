public interface IItensPedidoRepository
{
    Task<List<ItensPedido>> ObterTodosItensPedidos();
    Task<List<ItensPedido>> ObterItensPedidoPorId(int id);
    Task InserirItensPedido(ItensPedido itensPedido);
    Task AtualizarItensPedido(ItensPedido itensPedido);
    Task ExcluirItensPedido(int id);
}