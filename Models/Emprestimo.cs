using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Biblioteca_UniLib.Models;

public class Emprestimo
{
    [Key]
    public int EmprestimoID { get; set; }

    public int LeitorID { get; set; }

    public int LivroID { get; set; }

    [Required]
    public DateTime DataEmprestimo { get; set; }

    [Required]
    public DateTime DataDevolucaoPrevista { get; set; }

    public DateTime? DataDevolucao { get; set; }

    [ForeignKey("LeitorID")]
    public virtual Leitor Leitor { get; set; }

    [ForeignKey("LivroID")]
    public virtual Livro Livro { get; set; }
}
