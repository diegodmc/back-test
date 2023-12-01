using Microsoft.EntityFrameworkCore;

public class ItensPedidoRepository : IItensPedidoRepository
{
    private readonly AppDbContext _dbContext;

    public ItensPedidoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ItensPedido>> ObterTodosItensPedidos()
    {
        try
        {
            return await _dbContext.ItensPedidos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<List<ItensPedido>> ObterItensPedidoPorId(int id)
    {
        try
        {
            return await _dbContext.ItensPedidos.Where(e => e.PedidoId == id).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task InserirItensPedido(ItensPedido itensPedido)
    {
        try
        {
            _dbContext.ItensPedidos.Add(itensPedido);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task AtualizarItensPedido(ItensPedido itensPedido)
    {
        try
        {
            _dbContext.Entry(itensPedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task ExcluirItensPedido(int id)
    {
        try
        {
            var produto = await _dbContext.ItensPedidos.FindAsync(id);
            if (produto != null)
            {
                _dbContext.ItensPedidos.Remove(produto);
                await _dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }
}