using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Expense
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha del gasto es requisito.")]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La descripción del gasto es requisito.")]
        [MaxLength(50)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto del gasto es requisito.")]
        [Display(Name = "Monto")]
        public int Amount { get; set; } = 0;

        [Required(ErrorMessage = "Persona que autoriza es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Persona que autoriza")]
        public string? Approver { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
