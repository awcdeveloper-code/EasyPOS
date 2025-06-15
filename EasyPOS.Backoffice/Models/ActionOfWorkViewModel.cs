using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Models
{
    public class ActionOfWorkViewModel
    {
        public ActionOfWork? ActionOfWork { get; set; }
        public IEnumerable<SelectListItem>? Roles { get; set; }
    }
}
