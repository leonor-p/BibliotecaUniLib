using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Bibliotecario
{
    [Key]
    public int BibliotecarioID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    public int? BibliotecaID { get; set; }

    [ForeignKey("BibliotecaID")]
    public virtual Biblioteca Biblioteca { get; set; }
}
