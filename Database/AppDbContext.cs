using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItensPedido> ItensPedidos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

         optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), options =>
            {
               options.EnableRetryOnFailure();
            });
    }
}