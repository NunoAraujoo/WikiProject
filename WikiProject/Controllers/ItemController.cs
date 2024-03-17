using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WikiProject.Application.Common.Interfaces;
using WikiProject.Domain.Entities;
using WikiProject.Infrastructure.Data;
using WikiProject.Infrastructure.Repository;

namespace WikiProject.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly ApplicationDbContext _db;

        public ItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.Item.GetAll();
            return View(items);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Item obj)
        {
            //Custom Validation
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("", "The Description cannot exactly match the Name");
            }

            if (obj.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Item Images\");

                using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                obj.Image.CopyTo(fileStream);
                obj.ImageUrl = @"\images\Item Images\" + fileName;
            }
            else
                obj.ImageUrl = "https://placehold.co/600x400";

            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Update(int itemId)
        {
            Item? obj = _unitOfWork.Item.Get(u => u.Id == itemId);

            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Item obj)
        {
            if (obj.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\Item Images\");

                if (!string.IsNullOrEmpty(obj.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }

                using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                obj.Image.CopyTo(fileStream);

                obj.ImageUrl = @"\images\Item Images\" + fileName;
            }


            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "The item has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
        public IActionResult Delete(int itemId)
        {
            Item? obj = _unitOfWork.Item.Get(_ => _.Id == itemId);

            if (obj is null)
                return RedirectToAction("Error", "Home");

            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Item obj)
        {
            Item? objFromDb = _unitOfWork.Item.Get(_ => _.Id == obj.Id);



            if (objFromDb is not null)
            {
                if (!string.IsNullOrEmpty(objFromDb.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageUrl.TrimStart('\\'));


             if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }

                _unitOfWork.Item.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The item has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "The item could not be deleted.";
            return View(obj);
        }
    }
}
