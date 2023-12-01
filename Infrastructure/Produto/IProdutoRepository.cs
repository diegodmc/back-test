public interface IProdutoRepository
{
    Task<List<Produto>> ObterTodosProdutos();
    Task<Produto> ObterProdutoPorId(int id);
    Task InserirProduto(Produto produto);
    Task AtualizarProduto(Produto produto);
    Task<bool> ExcluirProduto(int id);
}