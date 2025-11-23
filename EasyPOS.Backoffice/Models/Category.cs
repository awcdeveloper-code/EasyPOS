using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EasyPOS.Backoffice.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
