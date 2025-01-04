using Microsoft.AspNetCore.Identity;

namespace Biblioteca_UniLib.Models
{
    public class PerfilRole
    {
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }

        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
    }


}
