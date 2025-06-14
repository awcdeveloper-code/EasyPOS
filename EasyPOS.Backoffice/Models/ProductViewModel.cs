using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
