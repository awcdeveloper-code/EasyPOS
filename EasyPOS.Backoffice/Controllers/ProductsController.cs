using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(AppDbContext appDbContext, ILogger<ProductsController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;            
        }

        public IActionResult Index()
        {
            _logger.LogInformation("ProductsController:Index called.");

            List<Product> prodList = _appDbContext.Products.ToList();

            return View(prodList);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("ProductsController:Create called.");

            var catList = _appDbContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            var model = new ProductViewModel
            {
                Product = new Product(),
                Categories = catList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel prodView)
        {
            _logger.LogInformation("ProductsController:CreatePOST called.");

            ModelState.Remove("Categories");

            if (ModelState.IsValid)
            {
                Product prod = new Product();
                prod = prodView.Product;

                int id = Convert.ToInt32(prodView.Product.Category);
                Category cat = _appDbContext.Categories.Find(id)!;
                prod.Category = cat.Name;

                _appDbContext.Products.Add(prod);
                _appDbContext.SaveChanges();
                TempData["success"] = "Producto creado exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("ProductsController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product prod = _appDbContext.Products.Find(id)!;

            if (prod == null)
            {
                return NotFound();
            }

            var catList = _appDbContext.Categories
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            var model = new ProductViewModel
            {
                Product = prod,
                Categories = catList
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel prodView)
        {
            _logger.LogInformation("ProductsController:EditPOST called.");

            ModelState.Remove("Categories");

            if (ModelState.IsValid)
            {
                Product prod = new Product();
                prod = prodView.Product;

                int id = Convert.ToInt32(prodView.Product.Category);
                Category cat = _appDbContext.Categories.Find(id)!;
                prod.Category = cat.Name;

                _appDbContext.Products.Update(prod);
                _appDbContext.SaveChanges();
                TempData["success"] = "Producto actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("ProductsController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product prod = _appDbContext.Products.Find(id)!;

            ProductViewModel model = new ProductViewModel();
            model.Product = prod;

            if (prod == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ProductViewModel prodView)
        {
            _logger.LogInformation("ProductsController:DeletePOST called.");

            ModelState.Remove("Categories");

            if (ModelState.IsValid)
            {
                Product prod = new Product();
                prod = prodView.Product;

                _appDbContext.Products.Remove(prod);
                _appDbContext.SaveChanges();
                TempData["success"] = "Producto borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
