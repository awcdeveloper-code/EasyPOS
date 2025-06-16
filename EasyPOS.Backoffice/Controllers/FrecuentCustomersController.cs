using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class FrecuentCustomersController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<FrecuentCustomersController> _logger;

        public FrecuentCustomersController(AppDbContext appDbContext, ILogger<FrecuentCustomersController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("FrecuentCustomersController:Index called.");

            List<FrecuentCustomer> frecustList = _appDbContext.FrecuentCustomers.ToList();

            return View(frecustList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FrecuentCustomer frecust)
        {
            _logger.LogInformation("FrecuentCustomersController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.FrecuentCustomers.Add(frecust);
                _appDbContext.SaveChanges();
                TempData["success"] = "Cliente Frecuente creado exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("FrecuentCustomersController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            FrecuentCustomer frecust = _appDbContext.FrecuentCustomers.Find(id)!;

            if (frecust == null)
            {
                return NotFound();
            }

            return View(frecust);
        }

        [HttpPost]
        public IActionResult Edit(FrecuentCustomer frecust)
        {
            _logger.LogInformation("FrecuentCustomersController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.FrecuentCustomers.Update(frecust);
                _appDbContext.SaveChanges();
                TempData["success"] = "Cliente Frecuente actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("FrecuentCustomersController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            FrecuentCustomer frecust = _appDbContext.FrecuentCustomers.Find(id)!;

            if (frecust == null)
            {
                return NotFound();
            }

            return View(frecust);
        }

        [HttpPost]
        public IActionResult Delete(FrecuentCustomer frecust)
        {
            _logger.LogInformation("FrecuentCustomersController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.FrecuentCustomers.Remove(frecust);
                _appDbContext.SaveChanges();
                TempData["success"] = "Cliente Frecuente borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
