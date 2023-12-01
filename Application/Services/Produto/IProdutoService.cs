using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProdutoService
{
    Task<List<Produto>> ObterTodosProdutos();
    Task<Produto> ObterProdutoPorId(int id);
    Task InserirProduto(Produto produto);
    Task AtualizarProduto(Produto produto);
    Task<bool> ExcluirProduto(int id);
}