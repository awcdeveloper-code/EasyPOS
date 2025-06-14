using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class NewFeatureRequest
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es un requisito.")]
        [MaxLength(50)]
        [Display(Name = "Nombre Completo")]
        public string? Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Número de Teléfono es un requisito.")]
        [MaxLength(10)]
        [Display(Name = "No. Teléfono")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Correo Electrónico es un requisito.")]
        [MaxLength(50)]
        [Display(Name = "Correo Electrónico")]
        public string? eMail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descripción de la Sugerencia es requisito")]
        [MaxLength(1000)]
        [Display(Name = "Descripción de la Sugerencia (Máximo 1000 caracteres)")]
        public string? Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
