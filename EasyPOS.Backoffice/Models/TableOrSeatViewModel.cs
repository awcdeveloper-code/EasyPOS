using System.ComponentModel.DataAnnotations;

namespace EasyPOS.Backoffice.Models
{
    public class TableOrSeatViewModel
    {
        public TableOrSeat tableSeat{ get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
