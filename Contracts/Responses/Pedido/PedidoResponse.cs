public class PedidoResponse
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public bool Pago { get; set; }
    public decimal ValorTotal { get; set; }
    public List<ItensPedidoDTO> ItensPedido { get; set; }
    
}