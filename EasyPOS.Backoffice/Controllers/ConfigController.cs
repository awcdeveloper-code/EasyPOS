using Microsoft.AspNetCore.Mvc;
using EasyPOS.Backoffice.Models;
using System.Threading.Tasks;
using EasyPOS.Backoffice.Data;

namespace EasyPOS.Backoffice.Controllers
{
    public class ConfigController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ConfigController> _logger;
        public ConfigController(AppDbContext appDbContext, ILogger<ConfigController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IActionResult Log()
        {
            _logger.LogInformation("ConfigController:Log called.");

            LogViewModel logViewModel = new LogViewModel();
            logViewModel.LogList = _appDbContext.Logger.ToList();

            return View(logViewModel);
        }

        [HttpPost]
        public IActionResult Log(DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("ConfigController:LogPOST called.");

            LogViewModel logViewModel = new LogViewModel();
            logViewModel.StartDate = startDate;
            logViewModel.EndDate = endDate;
            logViewModel.LogList = _appDbContext.Logger.Where(x => x.EntryDatetime >= startDate && x.EntryDatetime <= endDate).ToList();

            return View(logViewModel);
        }
    }
}
