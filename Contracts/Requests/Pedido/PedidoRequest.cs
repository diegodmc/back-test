public class PedidoRequest : BaseRequest
{
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public bool Pago { get; set; }
    public List<ItensPedidoDTO> ItensPedidos { get; set; }
}