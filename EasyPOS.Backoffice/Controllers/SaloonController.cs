using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            _logger.LogInformation("SaloonController:Index was called.");

            List<TableOrSeat> tableOrSeats = _appDbContext.TablesOrSeats.ToList();

            return View(tableOrSeats);
        }

        public async Task<IActionResult> TableAssignment(int id)
        {
            _logger.LogInformation("SaloonController:TableAssignment was called.");

            TableOrSeat ts = await _appDbContext.TablesOrSeats.FindAsync(id);

            if (ts != null)
            {
                ts.Status = true;
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TableDetail(int id)
        {
            _logger.LogInformation("SaloonController:TableDetail was called.");

            TableOrSeat ts = await _appDbContext.TablesOrSeats.FindAsync(id);

            return View(ts);
        }

        public async Task<IActionResult> TableAvailable(int id)
        {
            _logger.LogInformation("SaloonController:TableAvailable was called.");

            TableOrSeat ts = await _appDbContext.TablesOrSeats.FindAsync(id);

            if (ts != null)
            {
                ts.Status = false;
                await _appDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
