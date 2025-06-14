using Microsoft.AspNetCore.Mvc;
using EasyPOS.Backoffice.Models;
using System.Threading.Tasks;
using EasyPOS.Backoffice.Data;

namespace EasyPOS.Backoffice.Controllers
{
    public class ConfigController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ConfigController> _logger;
        public ConfigController(AppDbContext appDbContext, ILogger<ConfigController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Actions()
        {
            return View();
        }
        public IActionResult Log()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Buckets()
        {
            return View();
        }
        public IActionResult Promotions()
        {
            return View();
        }
        public IActionResult Saloon()
        {
            return View();
        }
        public IActionResult VIPCustomers()
        {
            return View();
        }
    }
}
