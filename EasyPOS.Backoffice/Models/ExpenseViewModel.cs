using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Models
{
    public class ExpenseViewModel
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> Approvers { get; set; }
    }
}
