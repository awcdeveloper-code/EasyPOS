using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class User
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El PIN de acceso es requisito.")]
        [Display(Name = "PIN de Acceso")]
        public int UserPIN { get; set; } = 0;

        [Required(ErrorMessage = "El Nombre Completo es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Nombre Completo")]
        public string? Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rol es requisito.")]
        [MaxLength(30)]
        [Display(Name = "Rol Asignado")]
        public string? Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es requisito.")]
        [MaxLength(20)]
        [Display(Name = "Estado")]
        public string? Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastLogin { get; set; } = DateTime.Now;
    }
}
