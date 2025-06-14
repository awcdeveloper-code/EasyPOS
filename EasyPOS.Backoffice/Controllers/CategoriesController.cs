using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyPOS.Backoffice.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(AppDbContext appDbContext, ILogger<CategoriesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;            
        }

        public IActionResult Index()
        {
            _logger.LogInformation("CategoriesController:Index called.");

            List<Category> catList = _appDbContext.Categories.ToList();

            return View(catList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("CategoriesController:Create called.");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat)
        {
            _logger.LogInformation("CategoriesController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Add(cat);
                _appDbContext.SaveChanges();
                TempData["success"] = "Categoría creada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("CategoriesController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category cat = _appDbContext.Categories.Find(id)!;

            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            _logger.LogInformation("CategoriesController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Update(cat);
                _appDbContext.SaveChanges();
                TempData["success"] = "Categoría actualizada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("CategoriesController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category cat = _appDbContext.Categories.Find(id)!;

            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category cat)
        {
            _logger.LogInformation("CategoriesController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Remove(cat);
                _appDbContext.SaveChanges();
                TempData["success"] = "Categoría borrada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
