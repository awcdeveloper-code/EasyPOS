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
        
        public IActionResult SaloonStatus()
        {
            _logger.LogInformation("SaloonController:SaloonStatus called.");

            List<TableOrSeat> tblseaList = _appDbContext.TablesOrSeats.ToList();

            return View(tblseaList);
        }

        public IActionResult Assign(int? id)
        {
            _logger.LogInformation("SaloonController:Assign called.");

            TableOrSeat tblsea = _appDbContext.TablesOrSeats.Find(id)!;

            if (tblsea == null)
            {
                return NotFound();
            }

            tblsea.Status = "OCUPADA";
            _appDbContext.TablesOrSeats.Update(tblsea);
            _appDbContext.SaveChanges();
            TempData["success"] = "Mesa/Barra asignada exitosamente.";

            return RedirectToAction("SaloonStatus");
        }

        public IActionResult Available(int? id)
        {
            _logger.LogInformation("SaloonController:Available called.");

            TableOrSeat tblsea = _appDbContext.TablesOrSeats.Find(id)!;

            if (tblsea == null)
            {
                return NotFound();
            }

            tblsea.Status = "DISPONIBLE";
            _appDbContext.TablesOrSeats.Update(tblsea);
            _appDbContext.SaveChanges();
            TempData["success"] = "Mesa/Barra asignada exitosamente.";

            return RedirectToAction("SaloonStatus");
        }

        public IActionResult UpdateTicket(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TableOrSeat ts = _appDbContext.TablesOrSeats.Find(id)!;

            TableOrSeatViewModel tsvm = new TableOrSeatViewModel();

            tsvm.tableSeat = ts;
            tsvm.Categories = _appDbContext.Categories.ToList();
            tsvm.Products = _appDbContext.Products.ToList();

            return View(tsvm);
        }
    }
}
