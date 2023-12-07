using Microsoft.AspNetCore.Mvc;
using WikiProject.Domain.Entities;
using WikiProject.Infrastructure.Data;

namespace WikiProject.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.Items.ToList();
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Update(int itemId)
        {
            Item? obj = _db.Items.FirstOrDefault(u => u.Id == itemId);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
