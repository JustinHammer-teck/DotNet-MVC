using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UoW;

        public CategoryController(IUnitOfWork uoW)
        {
            _UoW = uoW;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }

            category = _UoW.Category.Get(id.GetValueOrDefault());

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _UoW.Category.Add(category);
                }
                else
                {
                    _UoW.Category.Update(category);
                }

                _UoW.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _UoW.Category.GetAll();

            return Json(new {data = categories});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _UoW.Category.Get(id);
            if (obj == null)
            {
                return Json(new {success = false, message = "Something Wrong Happended"});
            }

            _UoW.Category.Remove(obj);
            _UoW.Save();
            return Json(new {success = true, message = "Successful"});
        }
    }
}