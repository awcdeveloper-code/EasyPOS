using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyPOS.Backoffice.Controllers
{
    public class RolesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<RolesController> _logger;

        public RolesController(AppDbContext appDbContext, ILogger<RolesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;            
        }

        public IActionResult Index()
        {
            _logger.LogInformation("RolesController:Index called.");

            List<Role> rolesList = _appDbContext.Roles.ToList();

            return View(rolesList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("RolesController:Create called.");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role rol)
        {
            _logger.LogInformation("RolesController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Roles.Add(rol);
                _appDbContext.SaveChanges();
                TempData["success"] = "Rol creado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("RolesController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Role rol = _appDbContext.Roles.Find(id)!;

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost]
        public IActionResult Edit(Role rol)
        {
            _logger.LogInformation("RolesController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Roles.Update(rol);
                _appDbContext.SaveChanges();
                TempData["success"] = "Rol actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("RolesController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Role rol = _appDbContext.Roles.Find(id)!;

            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        [HttpPost]
        public IActionResult Delete(Role rol)
        {
            _logger.LogInformation("RolesController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Roles.Remove(rol);
                _appDbContext.SaveChanges();
                TempData["success"] = "Rol borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
