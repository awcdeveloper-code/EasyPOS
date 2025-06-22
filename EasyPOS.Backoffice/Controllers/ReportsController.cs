using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(AppDbContext appDbContext, ILogger<ReportsController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult ProductsCatalog()
        {
            _logger.LogInformation("ReportsController:ProductsCatalog called.");

            return View();
        }
        public IActionResult InventoryStatus()
        {
            _logger.LogInformation("ReportsController:InventoryStatus called.");

            return View();
        }
    }
}
