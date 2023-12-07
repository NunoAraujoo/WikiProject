using Microsoft.AspNetCore.Mvc;
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
    }
}
