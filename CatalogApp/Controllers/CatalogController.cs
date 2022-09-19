using CatalogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CatalogApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly CatalogDbContext _dbContext;
        public CatalogController(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index1", _dbContext.CatalogItems.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create1", new CatalogItem());
        }

        [HttpPost]
        public IActionResult Create(CatalogItem data)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogItems.Add(new CatalogItem { Name = data.Name, Price = data.Price, Id = new Random().Next(), Quantity = data.Quantity, ImgPath = data.ImgPath });
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create1",data);
        }

        [HttpGet]
        public IActionResult Init()
        {
            if (_dbContext.CatalogItems.Any())
                return Ok("Db already initialised");
            _dbContext.CatalogItems.AddRange(new List<CatalogItem>
                {
                    new CatalogItem{Id = 1, Name = "Pinaple", Price = 90, Quantity = 7, ImgPath = ""},
                    new CatalogItem{Id = 2, Name = "Pen", Price = 3, Quantity = 100, ImgPath = ""},
                    new CatalogItem{Id = 3, Name = "Chair", Price = 350, Quantity = 10, ImgPath = ""}
                });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
