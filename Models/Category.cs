using System.ComponentModel.DataAnnotations;

namespace Biblioteca_UniLib.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [MaxLength(256, ErrorMessage = "{0} length cannot exceed {1}")]
        public string? Description { get; set; }
        public string? Author { get; set; }

        public bool State { get; set; } = true; //default value

        public ICollection<Course>? courses { get; set; }
    }
}