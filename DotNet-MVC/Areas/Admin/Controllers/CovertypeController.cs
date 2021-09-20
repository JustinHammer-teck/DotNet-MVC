using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Domain.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin)]

    public class CovertypeController : Controller
    {
        private readonly IUnitOfWork _UoW;

        public CovertypeController(IUnitOfWork uoW)
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
            CoverType coverType = new CoverType();
            if (id == null)
            {
                return View(coverType);
            }

            coverType = _UoW.Covertype.Get(id.GetValueOrDefault());

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                if (coverType.Id == 0)
                {
                    _UoW.Covertype.Add(coverType);
                }
                else
                {
                    _UoW.Covertype.Update(coverType);
                }

                _UoW.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(coverType);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var coverTypes = _UoW.Covertype.GetAll();

            return Json(new {data = coverTypes});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _UoW.Covertype.Get(id);
            if (obj == null)
            {
                return Json(new {success = false, message = "Something Wrong Happended"});
            }

            _UoW.Covertype.Remove(obj);
            _UoW.Save();
            return Json(new {success = true, message = "Successful"});
        }
    }
}