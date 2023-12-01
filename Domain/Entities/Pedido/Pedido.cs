using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
   
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [MaxLength(60, ErrorMessage = "O campo Nome não pode ter mais de 60 caracteres.")]
    public string NomeCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [MaxLength(60, ErrorMessage = "O campo Email não pode ter mais de 60 caracteres.")]
    public string EmailCliente { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public bool Pago { get; set; }
}