using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Biblioteca
{
    [Key]
    public int BibliotecaID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [MaxLength(255)]
    public string Localizacao { get; set; }

    [MaxLength(20)]
    public string Telefone { get; set; }
}
