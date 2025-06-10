using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class TablesAndSeats
    {
        [Key]
        public int Id { get; set; }
        public string? TableName { get; set; } = string.Empty;
        public int MumberOfOccupants { get; set; } = 0;
        public bool Status { get; set; } = false;
    }
}
