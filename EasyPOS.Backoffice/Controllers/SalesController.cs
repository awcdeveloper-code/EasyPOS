using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class SalesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<SalesController> _logger;

        public SalesController(AppDbContext appDbContext, ILogger<SalesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult TodaySales()
        {
            _logger.LogInformation("SalesController:TodaySales called.");

            return View();
        }

        public IActionResult OpenSales()
        {
            _logger.LogInformation("SalesController:OpenSales called.");

            return View();
        }
    }
}
