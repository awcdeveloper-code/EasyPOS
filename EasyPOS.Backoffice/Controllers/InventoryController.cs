using Microsoft.AspNetCore.Mvc;

namespace EasyPOS.Backoffice.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Providers()
        {
            return View();
        }
        public IActionResult Shopping()
        {
            return View();
        }
        public IActionResult Notes()
        {
            return View();
        }
        public IActionResult DamagedProducts()
        {
            return View();
        }
        public IActionResult InventoryCheck()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
    }
}
