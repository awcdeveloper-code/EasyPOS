using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EntryDatetime { get; set; }
        public int Action { get; set; }
    }
}
