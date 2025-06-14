using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Models
{
    public class UserViewModel
    {
        public User? User { get; set; }
        public IEnumerable<SelectListItem>? Roles { get; set; }
    }
}
