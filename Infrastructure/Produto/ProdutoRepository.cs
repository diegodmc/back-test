using Microsoft.EntityFrameworkCore;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _dbContext;

    public ProdutoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Produto>> ObterTodosProdutos()
    {
        try
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<Produto> ObterProdutoPorId(int id)
    {
        try
        {
            return await _dbContext.Produtos.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task InserirProduto(Produto produto)
    {
        try
        {
            _dbContext.Produtos.Add(produto);
            await _dbContext.SaveChangesAsync();
        }

        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task AtualizarProduto(Produto produto)
    {
        try
        {
            _dbContext.Entry(produto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        try
        {
            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto != null)
            {
                _dbContext.Produtos.Remove(produto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }
}