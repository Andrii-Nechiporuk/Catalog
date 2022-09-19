using CatalogApp.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View(_dbContext.CatalogItems.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CatalogItem());
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            _dbContext.CatalogItems.Add(new CatalogItem { Name = name, Price = 5, Id = new Random().Next(), Quantity = new Random().Next(), ImgPath = "" });
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
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
