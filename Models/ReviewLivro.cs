using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class ReviewLivro
{
    [Key]
    public int ReviewID { get; set; }

    public int LivroID { get; set; }

    public int LeitorID { get; set; }

    [Range(1, 5)]
    public int Avaliacao { get; set; }

    public string Comentario { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [ForeignKey("LivroID")]
    public virtual Livro Livro { get; set; }

    [ForeignKey("LeitorID")]
    public virtual Leitor Leitor { get; set; }
}
