using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Log
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [MaxLength(3)]
        [Display(Name = "Tipo")]
        public string? EntryType { get; set; }

        [MaxLength(30)]
        [Display(Name = "Colaborador")]
        public string ? UserId { get; set; }

        [Display(Name = "Fecha/Hora del Evento")]
        public DateTime EntryDatetime { get; set; }

        [MaxLength(255)]
        [Display(Name = "Descripción del Evento")]
        public string? EntryDescrption { get; set; }
    }
}
