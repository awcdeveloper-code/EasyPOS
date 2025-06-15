using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyPOS.Backoffice.Controllers
{
    public class TablesAndSeatsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<RolesController> _logger;

        public TablesAndSeatsController(AppDbContext appDbContext, ILogger<RolesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("TablesAndSeatsController:Index called.");

            List<TableOrSeat> TableOrSeatList = _appDbContext.TablesOrSeats.ToList();

            return View(TableOrSeatList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("TablesAndSeatsController:Create called.");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TableOrSeat ts)
        {
            _logger.LogInformation("TablesAndSeatsController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.TablesOrSeats.Add(ts);
                _appDbContext.SaveChanges();
                TempData["success"] = "Mesa/Barra creada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("TablesAndSeatsController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            TableOrSeat ts = _appDbContext.TablesOrSeats.Find(id)!;

            if (ts == null)
            {
                return NotFound();
            }

            return View(ts);
        }

        [HttpPost]
        public IActionResult Edit(TableOrSeat ts)
        {
            _logger.LogInformation("TablesAndSeatsController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.TablesOrSeats.Update(ts);
                _appDbContext.SaveChanges();
                TempData["success"] = "Mesa/Barra actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("TablesAndSeatsController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            TableOrSeat ts = _appDbContext.TablesOrSeats.Find(id)!;

            if (ts == null)
            {
                return NotFound();
            }

            return View(ts);
        }

        [HttpPost]
        public IActionResult Delete(TableOrSeat ts)
        {
            _logger.LogInformation("TablesAndSeatsController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.TablesOrSeats.Remove(ts);
                _appDbContext.SaveChanges();
                TempData["success"] = "Rol borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
