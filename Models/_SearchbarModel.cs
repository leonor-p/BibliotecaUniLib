using Biblioteca_UniLib.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Biblioteca_UniLib.Views.Shared
{
    public class _SearchbarModel
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        // Adicione outros campos necessários para a view
    }
}