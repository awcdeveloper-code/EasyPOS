using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class TableOrSeat
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo es requisito.")]
        [MaxLength(5)]
        [Display(Name = "Tipo")]
        public string? Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Nombre es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Número de Ocupantes es requisito.")]
        [Display(Name = "Número de Ocupantes")]
        public int Occupants { get; set; } = 0;

        [Required(ErrorMessage = "El estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string? Status { get; set; } = string.Empty;

        public string? GUID { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
