using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Notificacao
{
    [Key]
    public int NotificacaoID { get; set; }

    public int LeitorID { get; set; }

    public string Mensagem { get; set; }

    public string Tipo { get; set; }

    public bool Lida { get; set; } = false;

    public DateTime DataEnvio { get; set; } = DateTime.Now;

    [ForeignKey("LeitorID")]
    public virtual Leitor Leitor { get; set; }
}
