using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Biblioteca_UniLib.Models
{
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

        public DateTime? AnoPublicacao { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }

        public string Resumo { get; set; }

        public string Editora { get; set; }

        public int CopiasDisponiveis { get; set; }

        public string ImagemUrl { get; set; }

        public bool EmDestaque { get; set; }
    }
}
