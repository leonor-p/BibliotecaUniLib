using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;




    public class Perfil
    {
    [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }


