using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyPOS.Backoffice.Models
{
    public class Action
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
