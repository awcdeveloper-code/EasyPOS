using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Promotion
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; } = string.Empty;

        [MaxLength(30)]
        [Display(Name = "Contenido de la Promoción")]
        public string? BucketContent { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
