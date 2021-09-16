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
            Caterogy caterogy = new Caterogy();
            if (id == null)
            {
                return View(caterogy);
            }

            caterogy = _UoW.Caterogy.Get(id.GetValueOrDefault());

            if (caterogy == null)
            {
                return NotFound();
            }

            return View(caterogy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Caterogy caterogy)
        {
            if (ModelState.IsValid)
            {
                if (caterogy.Id == 0)
                {
                    _UoW.Caterogy.Add(caterogy);
                }
                else
                {
                    _UoW.Caterogy.Update(caterogy);
                }

                _UoW.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(caterogy);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _UoW.Caterogy.GetAll();

            return Json(new {data = categories});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _UoW.Caterogy.Get(id);
            if (obj == null)
            {
                return Json(new {success = false, message = "Something Wrong Happended"});
            }

            _UoW.Caterogy.Remove(obj);
            _UoW.Save();
            return Json(new {success = true, message = "Successful"});
        }
    }
}