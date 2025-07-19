using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Biblioteca_UniLib.Models
{
    
        public class SearchModel
        {
            public List<string> Results { get; set; }

            public SearchModel()
            {
                Results = new List<string>();
            }
        }
}
