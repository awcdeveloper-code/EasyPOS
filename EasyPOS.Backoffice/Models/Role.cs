using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
