using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyPOS.Backoffice.Controllers
{
    public class SaloonController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<SaloonController> _logger;

        public SaloonController(AppDbContext appDbContext, ILogger<SaloonController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("SaloonController:Index called.");

            List<TablesAndSeats> tablesAndSeats = _appDbContext.TablesAndSeats.ToList();
            
            return View(tablesAndSeats);
        }
    }
}
