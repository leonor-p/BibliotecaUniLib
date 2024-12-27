using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Livro
{
    [Key]
    public int LivroID { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; }

    [MaxLength(100)]
    public string Autor { get; set; }

    [MaxLength(50)]
    public string Categoria { get; set; }

    [MaxLength(50)]
    public string Tema { get; set; }

    public int? AnoPublicacao { get; set; }

    [MaxLength(20)]
    public string ISBN { get; set; }

    public string Resumo { get; set; }

    public int CopiasDisponiveis { get; set; }
}
