using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Produto é obrigatório.")]
    [MaxLength(20, ErrorMessage = "O campo Produto não pode ter mais de 20 caracteres.")]
    public string NomeProduto { get; set; }

    [Range(typeof(decimal), "0.01", "9999999.99", ErrorMessage = "O valor deve estar entre 0.01 e 9999999.99")]
    public decimal Valor { get; set; } 
}