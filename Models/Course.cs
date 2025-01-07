
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_UniLib.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(256, ErrorMessage = "length can not exceed {1} characters")]
        public string Description { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public Boolean State { get; set; }
        public Boolean Dest { get; set; }
        public Boolean Addrec { get; set; }
        public string? CoverPhoto { get; set; }
        //public string? Document { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
