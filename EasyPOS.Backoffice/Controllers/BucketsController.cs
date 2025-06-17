using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyPOS.Backoffice.Controllers
{
    public class BucketsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<BucketsController> _logger;

        public BucketsController(AppDbContext appDbContext, ILogger<BucketsController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("BucketsController:Index called.");

            List<Bucket> bucketList = _appDbContext.Buckets.ToList();

            return View(bucketList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bucket bucket)
        {
            _logger.LogInformation("BucketsController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Buckets.Add(bucket);
                _appDbContext.SaveChanges();
                TempData["success"] = "Balde creado exitosamente.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            _logger.LogInformation("BucketsController:Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Bucket bucket = _appDbContext.Buckets.Find(id)!;

            if (bucket == null)
            {
                return NotFound();
            }

            return View(bucket);
        }

        [HttpPost]
        public IActionResult Edit(Bucket bucket)
        {
            _logger.LogInformation("BucketsController:EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Buckets.Update(bucket);
                _appDbContext.SaveChanges();
                TempData["success"] = "Balde actualizado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            _logger.LogInformation("BucketsController:Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Bucket bucket = _appDbContext.Buckets.Find(id)!;

            if (bucket == null)
            {
                return NotFound();
            }

            return View(bucket);
        }

        [HttpPost]
        public IActionResult Delete(Bucket bucket)
        {
            _logger.LogInformation("BucketsController:DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.Buckets.Remove(bucket);
                _appDbContext.SaveChanges();
                TempData["success"] = "Balde borrado exitosamente.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
