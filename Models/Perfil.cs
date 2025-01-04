using Biblioteca_UniLib.Models;
using System.ComponentModel.DataAnnotations;

public class Perfil
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    // Propriedade de navegação para muitos-para-muitos
    public ICollection<PerfilRole> PerfilRoles { get; set; } = new List<PerfilRole>();
}
