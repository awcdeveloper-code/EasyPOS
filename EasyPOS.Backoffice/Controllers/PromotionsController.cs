using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<PromotionsController> _logger;

        public PromotionsController(AppDbContext appDbContext, ILogger<PromotionsController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("PromotionsController:Index called.");

            List<Promotion> promoList = _appDbContext.Promotions.ToList();

            return View(promoList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Promotion promo)
        {
            _logger.LogInformation("PromotionsController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Promotions.Add(promo);
                _appDbContext.SaveChanges();
                TempData["success"] = "Promoción creada exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("PromotionsController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Promotion promo = _appDbContext.Promotions.Find(id)!;

            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        [HttpPost]
        public IActionResult Edit(Promotion promo)
        {
            _logger.LogInformation("PromotionsController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Promotions.Update(promo);
                _appDbContext.SaveChanges();
                TempData["success"] = "Promoción actualizada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("PromotionsController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Promotion promo = _appDbContext.Promotions.Find(id)!;

            if (promo == null)
            {
                return NotFound();
            }

            return View(promo);
        }

        [HttpPost]
        public IActionResult Delete(Promotion promo)
        {
            _logger.LogInformation("PromotionsController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Promotions.Remove(promo);
                _appDbContext.SaveChanges();
                TempData["success"] = "Promoción borrada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
