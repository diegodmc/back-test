using Microsoft.EntityFrameworkCore;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _dbContext;

    public PedidoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Pedido>> ObterTodosPedidos()
    {
        try
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<Pedido> ObterPedidoPorId(int id)
    {
        try
        {
            return await _dbContext.Pedidos.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

public async Task<Pedido> ObterPedidoPorNomeCliente(string nome)
    {
        try
        {
            return await _dbContext.Pedidos.Where(e => e.NomeCliente.ToLower() == nome.ToLower()).FirstAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }
    public async Task<Pedido> InserirPedido(Pedido pedido)
    {
        try
        {
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task AtualizarPedido(Pedido pedido)
    {
        try
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }

    public async Task<bool> ExcluirPedido(int id)
    {
        try
        {
            var pedido = await _dbContext.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _dbContext.Pedidos.Remove(pedido);
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