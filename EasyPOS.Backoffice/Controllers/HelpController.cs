using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyPOS.Backoffice.Controllers
{
    public class HelpController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<CategoriesController> _logger;

        public HelpController(AppDbContext appDbContext, ILogger<CategoriesController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #region NEW FEATURE REQUEST
        public IActionResult NewFeatureRequest_Index()
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_Index called.");

            List<NewFeatureRequest> nfrList = _appDbContext.NewFeatureRequests.ToList();

            return View(nfrList);
        }

        public IActionResult NewFeatureRequest_Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewFeatureRequest_Create(NewFeatureRequest nfr)
        {
            _logger.LogInformation("HelpController:CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.NewFeatureRequests.Add(nfr);
                _appDbContext.SaveChanges();
                TempData["success"] = "Sugerencia creada exitosamente.";
                return RedirectToAction("NewFeatureRequest_Index");
            }
            return View();
        }

        public IActionResult NewFeatureRequest_Edit(int? id)
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            NewFeatureRequest nfr = _appDbContext.NewFeatureRequests.Find(id)!;

            if (nfr == null)
            {
                return NotFound();
            }

            return View(nfr);
        }

        [HttpPost]
        public IActionResult NewFeatureRequest_Edit(NewFeatureRequest nfr)
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.NewFeatureRequests.Update(nfr);
                _appDbContext.SaveChanges();
                TempData["success"] = "Sugerencia actualizada exitosamente.";
                return RedirectToAction("NewFeatureRequest_Index");
            }
            return View();
        }

        public IActionResult NewFeatureRequest_Delete(int? id)
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            NewFeatureRequest nfr = _appDbContext.NewFeatureRequests.Find(id)!;

            if (nfr == null)
            {
                return NotFound();
            }

            return View(nfr);
        }

        [HttpPost]
        public IActionResult NewFeatureRequest_Delete(NewFeatureRequest nfr)
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.NewFeatureRequests.Remove(nfr);
                _appDbContext.SaveChanges();
                TempData["success"] = "Sugerencia borrada exitosamente.";
                return RedirectToAction("NewFeatureRequest_Index");
            }
            return View();
        }
        #endregion

        public IActionResult GetHelp()
        {
            return View();
        }
        public IActionResult InitialTour()
        {
            return View();
        }
        public IActionResult TipsAndTricks()
        {
            return View();
        }
        public IActionResult WhatsNew()
        {
            return View();
        }

        #region REPORT A PROBLEM
        public IActionResult ReportProblem_Index()
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_Index called.");

            List<ReportProblem> rptProb = _appDbContext.ReportProblems.ToList();

            return View(rptProb);
        }

        public IActionResult ReportProblem_Create()
        {
            _logger.LogInformation("HelpController:ReportProblem_Create called.");

            return View();
        }
        
        [HttpPost]
        public IActionResult ReportProblem_Create(ReportProblem rptprob)
        {
            _logger.LogInformation("HelpController:ReportProblem_CreatePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.ReportProblems.Add(rptprob);
                _appDbContext.SaveChanges();
                TempData["success"] = "Reporte de Problema creado exitosamente.";
                return RedirectToAction("ReportProblem_Index");
            }
            return View();
        }

        public IActionResult ReportProblem_Edit(int? id)
        {
            _logger.LogInformation("HelpController:ReportProblem_Edit called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ReportProblem rptprob = _appDbContext.ReportProblems.Find(id)!;

            if (rptprob == null)
            {
                return NotFound();
            }

            return View(rptprob);
        }

        [HttpPost]
        public IActionResult ReportProblem_Edit(ReportProblem rptprob)
        {
            _logger.LogInformation("HelpController:NewFeatureRequest_ReportProblem_EditPOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.ReportProblems.Update(rptprob);
                _appDbContext.SaveChanges();
                TempData["success"] = "Reporte de Problema actualizado exitosamente.";
                return RedirectToAction("ReportProblem_Index");
            }
            return View();
        }

        public IActionResult ReportProblem_Delete(int? id)
        {
            _logger.LogInformation("HelpController:ReportProblem_Delete called.");

            if (id == null || id == 0)
            {
                return NotFound();
            }

            ReportProblem rptprob = _appDbContext.ReportProblems.Find(id)!;

            if (rptprob == null)
            {
                return NotFound();
            }

            return View(rptprob);
        }

        [HttpPost]
        public IActionResult ReportProblem_Delete(ReportProblem rptprob)
        {
            _logger.LogInformation("HelpController:ReportProblem_DeletePOST called.");

            if (ModelState.IsValid)
            {
                _appDbContext.ReportProblems.Remove(rptprob);
                _appDbContext.SaveChanges();
                TempData["success"] = "Reporte de Problema borrado exitosamente.";
                return RedirectToAction("ReportProblem_Index");
            }
            return View();
        }

        #endregion
        public IActionResult SuggestNewFeature()
        {
            return View();
        }
        public IActionResult TechnicalSupport()
        {
            return View();
        }
        public IActionResult CheckForUpdates()
        {
            return View();
        }
        public IActionResult TermsAndConditions(Models.EasyPOS ep)
        {
            return View(ep);
        }
        public IActionResult AboutEasyPOS()
        {
            return View();
        }
    }
}
