using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductsController> _logger;

        public UsersController(AppDbContext appDbContext, ILogger<ProductsController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;            
        }

        public IActionResult Index()
        {
            _logger.LogInformation("UsersController:Index called.");

            List<User> userList = _appDbContext.Users.ToList();

            return View(userList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("UsersController:Create called.");

            var rolesList = _appDbContext.Roles
                .OrderBy(c => c.Description)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Description
                })
                .ToList();

            var model = new UserViewModel
            {
                User = new User(),
                Roles = rolesList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(UserViewModel userView)
        {
            _logger.LogInformation("UsersController:CreatePOST called.");

            ModelState.Remove("Roles");

            if (ModelState.IsValid)
            {
                User user = new User();
                user = userView.User!;

                int id = Convert.ToInt32(userView.User!.Role);
                Role role = _appDbContext.Roles.Find(id)!;
                user.Role = role.Description;

                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
                TempData["success"] = "Usuario creado exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("UsersController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            User user = _appDbContext.Users.Find(id)!;

            if (user == null)
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

            var model = new UserViewModel
            {
                User = user,
                Roles = rolesList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userView)
        {
            _logger.LogInformation("UsersController:EditPOST called.");

            ModelState.Remove("Roles");

            if (ModelState.IsValid)
            {
                User user = new User();
                user = userView.User!;

                int id = Convert.ToInt32(userView.User!.Role);
                Role role = _appDbContext.Roles.Find(id)!;
                user.Role = role.Description;

                _appDbContext.Users.Update(user);
                _appDbContext.SaveChanges();
                TempData["success"] = "Usuario actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("UsersController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            User user = _appDbContext.Users.Find(id)!;

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            _logger.LogInformation("UsersController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
                TempData["success"] = "Usuario borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
