using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class ActionsOfWorkController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ActionsOfWorkController> _logger;

        public ActionsOfWorkController(AppDbContext appDbContext, ILogger<ActionsOfWorkController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;            
        }

        public IActionResult Index()
        {
            _logger.LogInformation("ActionsOfWorkController:Index called.");

            List<ActionOfWork> actionList = _appDbContext.ActionsOfWork.ToList();

            return View(actionList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("ActionsOfWorkController:Create called.");

            var rolesList = _appDbContext.Roles
                .OrderBy(c => c.Description)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Description
                })
                .ToList();

            var model = new ActionOfWorkViewModel
            {
                ActionOfWork = new ActionOfWork(),
                Roles = rolesList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ActionOfWorkViewModel actionView)
        {
            _logger.LogInformation("ActionsOfWorkController:CreatePOST called.");

            ModelState.Remove("Roles");

            if (ModelState.IsValid)
            {
                ActionOfWork aow = new ActionOfWork();
                aow = actionView.ActionOfWork!;

                int id = Convert.ToInt32(actionView.ActionOfWork!.Role);
                Role role = _appDbContext.Roles.Find(id)!;
                aow.Role = role.Description;

                _appDbContext.ActionsOfWork.Add(aow);
                _appDbContext.SaveChanges();
                TempData["success"] = "Acción de Trabajo creada exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("ActionsOfWorkController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ActionOfWork aow = _appDbContext.ActionsOfWork.Find(id)!;

            if (aow == null)
            {
                return NotFound();
            }

            var rolesList = _appDbContext.Roles
                .OrderBy(c => c.Description)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Description
                })
                .ToList();

            var model = new ActionOfWorkViewModel
            {
                ActionOfWork = aow,
                Roles = rolesList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ActionOfWorkViewModel actionView)
        {
            _logger.LogInformation("ActionsOfWorkController:EditPOST called.");

            ModelState.Remove("Roles");

            if (ModelState.IsValid)
            {
                ActionOfWork aow = new ActionOfWork();
                aow = actionView.ActionOfWork!;

                int id = Convert.ToInt32(actionView.ActionOfWork!.Role);
                Role role = _appDbContext.Roles.Find(id)!;
                aow.Role = role.Description;

                _appDbContext.ActionsOfWork.Update(aow);
                _appDbContext.SaveChanges();
                TempData["success"] = "Acción de Trabajo actualizada exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("ActionsOfWorkController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ActionOfWork aow = _appDbContext.ActionsOfWork.Find(id)!;

            if (aow == null)
            {
                return NotFound();
            }

            return View(aow);
        }

        [HttpPost]
        public IActionResult Delete(ActionOfWork aow)
        {
            _logger.LogInformation("ActionsOfWorkController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.ActionsOfWork.Remove(aow);
                _appDbContext.SaveChanges();
                TempData["success"] = "Acción de Trabajo borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
