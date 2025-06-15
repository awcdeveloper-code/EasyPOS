using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPOS.Backoffice.Models
{
    public class ActionOfWork
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Descripción")]
        public string? Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rol asignado es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Rol Asignado")]
        public string? Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string? Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
