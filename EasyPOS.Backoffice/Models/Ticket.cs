using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TicketDate { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; } = 0;

        [Required]
        public string? GUID { get; set; } = string.Empty;

        [Required]
        public int ServiceFee { get; set; } = 0;

        [Required]
        public int Tax { get; set; } = 0;

        [Required]
        public int TotalPrice { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ClosedAt { get; set; } = DateTime.Now;
    }
}
