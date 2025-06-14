using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es un requisito.")]
        [MaxLength(50)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es un requisito.")]
        [MaxLength(30)]
        [Display(Name = "Categoría")]
        public string? Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rango válido para el costo va desde 500 hasta 500,000 colones")]
        [Range(100, 500000)]
        [Display(Name = "Costo")]
        public int Cost { get; set; } = 0;

        [Required(ErrorMessage = "El rango válido para el precio va desde 500 hasta 500,000 colones")]
        [Display(Name = "Precio")]
        public int Price { get; set; } = 0;

        [Required(ErrorMessage = "La existencia va desde 0 hasta 10.000 unidades.")]
        [Range(0, 10000)]
        [Display(Name = "Existencias")]
        public int Stock { get; set; } = 0;

        [Required(ErrorMessage = "El estado es un requisito.")]
        [Display(Name = "Estado")]
        public string? Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
