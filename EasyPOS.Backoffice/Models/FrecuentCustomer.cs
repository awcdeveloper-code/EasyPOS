using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class FrecuentCustomer
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "Número Teléfono")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Correo Electrónico")]
        public string? eMailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "El límite de crédito es requisito.")]
        [Display(Name = "Límite de Crédito")]
        public int LimitOfCredit { get; set; } = 0;

        [Required(ErrorMessage = "Libre de Cargos es requisito.")]
        [MaxLength(2)]
        [Display(Name = "Libre de Cargos")]
        public string? FreeOfCharge { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string? Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastVisit { get; set; } = DateTime.Now;
    }
}
