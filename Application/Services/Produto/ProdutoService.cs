using System.Collections.Generic;
using System.Threading.Tasks;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> ObterTodosProdutos()
    {
        return await _produtoRepository.ObterTodosProdutos();
    }

    public async Task<Produto> ObterProdutoPorId(int id)
    {
        return await _produtoRepository.ObterProdutoPorId(id);
    }

    public async Task InserirProduto(Produto produto)
    {
        await _produtoRepository.InserirProduto(produto);
    }

    public async Task AtualizarProduto(Produto produto)
    {
        await _produtoRepository.AtualizarProduto(produto);
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        return await _produtoRepository.ExcluirProduto(id);
    }
}