using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public enum TicketStatus
    {
        Normal = 0,
        Open = 1,
        Aborted = 2,
        Cancelleded = 3
    }

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
        public int Status { get; set; } = (int)TicketStatus.Normal;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime ClosedAt { get; set; } = DateTime.Now;
    }
}
