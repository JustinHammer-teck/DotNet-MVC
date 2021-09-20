using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _UoW;

        public CompanyController(IUnitOfWork uoW)
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
            Company company = new Company();
            if (id == null)
            {
                return View(company);
            }

            company = _UoW.Company.Get(id.GetValueOrDefault());

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _UoW.Company.Add(company);
                }
                else
                {
                    _UoW.Company.Update(company);
                }

                _UoW.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(company);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _UoW.Company.GetAll();

            return Json(new {data = companies});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _UoW.Company.Get(id);
            if (obj == null)
            {
                return Json(new {success = false, message = "Something Wrong Happended"});
            }

            _UoW.Company.Remove(obj);
            _UoW.Save();
            return Json(new {success = true, message = "Successful"});
        }
    }
}