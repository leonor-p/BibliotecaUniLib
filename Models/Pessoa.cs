using System.ComponentModel.DataAnnotations;

namespace Biblioteca_UniLib.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}
