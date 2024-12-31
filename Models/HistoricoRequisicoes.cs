using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Biblioteca_UniLib.Models;

public class HistoricoRequisicoes
{
    [Key]
    public int HistoricoID { get; set; }

    public int LeitorID { get; set; }

    public int LivroID { get; set; }

    public DateTime DataAcao { get; set; } = DateTime.Now;

    [MaxLength(50)]
    public string Acao { get; set; }

    [ForeignKey("LeitorID")]
    public virtual Leitor Leitor { get; set; }

    [ForeignKey("LivroID")]
    public virtual Livro Livro { get; set; }
}
