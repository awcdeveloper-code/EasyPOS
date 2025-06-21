using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class TicketDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? GUID { get; set; } = string.Empty;

        [Required]
        public int ProdId { get; set; } = 0;

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public int UnitPrice { get; set; } = 0;

        [Required]
        public int TotalPrice { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
