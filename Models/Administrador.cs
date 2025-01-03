using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Administrador
{
    [Key]
    public int AdminID { get; set; }

    [Required]
    [MaxLength(100)]
<<<<<<< HEAD
    public string? Nome { get; set; }
=======
    public string Nome { get; set; } = string.Empty;
>>>>>>> 13a865ed738cfe968ee7cd630f2fe836d92e9499

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Senha { get; set; } = string.Empty;

    public int? CreatedByAdminID { get; set; } 

    [ForeignKey("CreatedByAdminID")]
    public virtual Administrador CreatedByAdmin { get; set; }
}
