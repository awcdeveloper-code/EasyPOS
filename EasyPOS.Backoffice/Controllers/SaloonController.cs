using EasyPOS.Backoffice.Data;
using EasyPOS.Backoffice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EasyPOS.Backoffice.Controllers
{
    public class SaloonController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<SaloonController> _logger;

        public SaloonController(AppDbContext appDbContext, ILogger<SaloonController> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        
        public IActionResult SaloonStatus()
        {
            _logger.LogInformation("SaloonController:SaloonStatus called.");

            List<TableOrSeat> tblseaList = _appDbContext.TablesOrSeats.ToList();

            return View(tblseaList);
        }

        public IActionResult AssignTicket(int id)
        {
            _logger.LogInformation("SaloonController:Assign called.");

            Ticket ticket = new Ticket();
            ticket.TicketDate = DateTime.Now.ToString("yyyyMMdd");
            ticket.CustomerId = id;

            Guid guid = Guid.NewGuid();

            ticket.GUID = guid.ToString();
            ticket.Status = (int)TicketStatus.Open;
            ticket.CreatedAt = DateTime.Now;

            _appDbContext.Tickets.Add(ticket);
            _appDbContext.SaveChanges();

            TableOrSeat tblsea = _appDbContext.TablesOrSeats.Find(id)!;

            if (tblsea == null)
            {
                return NotFound();
            }

            tblsea.Status = "OCUPADA";
            tblsea.GUID = guid.ToString();
            tblsea.Ticket = ticket.Id;

            _appDbContext.TablesOrSeats.Update(tblsea);
            _appDbContext.SaveChanges();

            TempData["success"] = "Mesa/Barra asignada exitosamente.";

            return RedirectToAction("SaloonStatus");
        }

        public IActionResult UpdateTicket(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            TableOrSeat ts = _appDbContext.TablesOrSeats.Find(id)!;

            List<Category> catList = _appDbContext.Categories.ToList();
            List<Product> prodList = _appDbContext.Products.ToList();

            SaloonViewModel svm = new SaloonViewModel();

            svm.TableOrSeat = ts;

            svm.Categories = new List<CategoryList>();
            svm.CategoryItems = new Dictionary<int, List<ProductList>>();

            foreach (Category cat in catList)
            {
                CategoryList cl = new CategoryList();

                cl.Id = cat.Id;
                cl.Name = cat.Description!;


                svm.Categories!.Add(cl);

                List<ProductList> productsList = new List<ProductList>();

                foreach (Product prod in prodList.Where(x => x.Category == cat.Description).ToList())
                {
                    ProductList pList = new ProductList();
                    pList.Id = prod.Id;
                    pList.Name = prod.Description!;
                    pList.Price = prod.Price;
                    productsList.Add(pList);
                }

                svm.CategoryItems!.Add(cat.Id,productsList);
            }

            return View(svm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTicket(string selectedItemsJson)
        {
            if (string.IsNullOrEmpty(selectedItemsJson))
            {
                ModelState.AddModelError(string.Empty, "No items selected.");
                return View();
            }

            List<SelectedItem> selectedItems = JsonSerializer.Deserialize<List<SelectedItem>>(selectedItemsJson);

            foreach(SelectedItem si in selectedItems!)
            {
                TicketDetail td = new TicketDetail();

                td.GUID = si.guid;
                td.ProdId = si.id;
                td.Quantity = si.quantity;
                td.UnitPrice = si.price;
                td.TotalPrice = si.price * si.quantity;

                _appDbContext.TicketDetails.Add(td);
            }

            _appDbContext.SaveChanges();

            return RedirectToAction("SaloonStatus");
        }

        public IActionResult PrintTicket(int id)
        {
            _logger.LogInformation("SaloonController:PrintTicket called.");

            return View();
        }

        public IActionResult PayTicket(int id)
        {
            _logger.LogInformation("SaloonController:PayTicket called.");

            return View();
        }

        public IActionResult Available(int? id)
        {
            _logger.LogInformation("SaloonController:Available called.");

            TableOrSeat tblsea = _appDbContext.TablesOrSeats.Find(id)!;

            if (tblsea == null)
            {
                return NotFound();
            }

            tblsea.Status = "DISPONIBLE";
            tblsea.GUID = string.Empty;

            _appDbContext.TablesOrSeats.Update(tblsea);
            _appDbContext.SaveChanges();

            TempData["success"] = "Mesa/Barra asignada exitosamente.";

            return RedirectToAction("SaloonStatus");
        }

    }
}
