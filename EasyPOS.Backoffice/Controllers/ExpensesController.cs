using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(AppDbContext appDbContext, ILogger<ExpensesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("ExpensesController:Index called.");

            List<Expense> expList = _appDbContext.Expenses.ToList();

            return View(expList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("ExpensesController:Create called.");

            var appList = _appDbContext.Users
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            var model = new ExpenseViewModel
            {
                Expense = new Expense(),
                Approvers = appList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ExpenseViewModel expView)
        {
            _logger.LogInformation("ExpensesController:CreatePOST called.");

            ModelState.Remove("Approvers");

            if (ModelState.IsValid)
            {
                Expense exp = new Expense();
                exp = expView.Expense;

                int id = Convert.ToInt32(expView.Expense.Approver);
                User user = _appDbContext.Users.Find(id)!;
                exp.Approver = user.Name;

                _appDbContext.Expenses.Add(exp);
                _appDbContext.SaveChanges();
                TempData["success"] = "Gasto creado exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("ExpensesController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Expense exp = _appDbContext.Expenses.Find(id)!;

            if (exp == null)
            {
                return NotFound();
            }

            var appList = _appDbContext.Users
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            var model = new ExpenseViewModel
            {
                Expense = exp,
                Approvers = appList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ExpenseViewModel expView)
        {
            _logger.LogInformation("ExpensesController:EditPOST called.");

            ModelState.Remove("Approvers");

            if (ModelState.IsValid)
            {
                Expense exp = new Expense();
                exp = expView.Expense;

                int id = Convert.ToInt32(expView.Expense.Approver);
                User user = _appDbContext.Users.Find(id)!;
                exp.Approver = user.Name;

                _appDbContext.Expenses.Update(exp);
                _appDbContext.SaveChanges();
                TempData["success"] = "Gasto actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("ExpensesController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Expense exp = _appDbContext.Expenses.Find(id)!;

            return View(exp);
        }

        [HttpPost]
        public IActionResult Delete(Expense exp)
        {
            _logger.LogInformation("ExpensesController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Expenses.Remove(exp);
                _appDbContext.SaveChanges();
                TempData["success"] = "Gasto borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
