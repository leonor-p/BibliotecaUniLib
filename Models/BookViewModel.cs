using System.ComponentModel.DataAnnotations;

namespace Biblioteca_UniLib.Models
{
    public class BookViewModel
    {

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string? Name { get; set; }
        public string? ISBN { get; set; }

        [Required(ErrorMessage = "Select a Image File")]
        public IFormFile? CoverPhoto { get; set; }
        [Required(ErrorMessage = "Select a Document File")]
        //public IFormFile? Document { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public int Quantidade { get; set; }
        public int Count { get; set; }
        public string? Author { get; set; }
        public Boolean State { get; set; }
        public Boolean Dest { get; set; }
        public Boolean Addrec { get; set; }



    }
}
