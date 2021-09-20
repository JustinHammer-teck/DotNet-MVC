using System;
using System.IO;
using System.Linq;
using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Domain.ViewModel;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace DotNet_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UoW;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork uoW,
            IWebHostEnvironment hostEnvironment)
        {
            _UoW = uoW;
            _hostEnvironment = hostEnvironment;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductVM productVm = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _UoW.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                CoverTypeList = _UoW.Covertype.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id == null)
            {
                return View(productVm);
            }

            productVm.Product = _UoW.Product.Get(id.GetValueOrDefault());

            if (productVm.Product == null)
            {
                return NotFound();
            }

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(webRootPath, @"uploads\images\products");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (productVM.Product.ImageUrl != null)
                    {
                        var imagePath = Path.Combine(webRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\uploads\images\products\" + fileName + extension;
                }
                else
                {
                    if (productVM.Product.Id != 0)
                    {
                        Product obj = _UoW.Product.Get(productVM.Product.Id);
                        productVM.Product.ImageUrl = obj.ImageUrl;
                    }
                }

                if (productVM.Product.Id == 0)
                {
                    _UoW.Product.Add(productVM.Product);
                }
                else
                {
                    _UoW.Product.Update(productVM.Product);
                }

                _UoW.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                productVM.CategoryList = _UoW.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                productVM.CoverTypeList = _UoW.Covertype.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                if (productVM.Product.Id != 0 )
                {
                    productVM.Product = _UoW.Product.Get(productVM.Product.Id);
                }
            }
            return View(productVM);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _UoW.Product.GetAll(includeProperties: "Category,CoverType");

            return Json(new {data = products});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _UoW.Product.Get(id);
            if (obj == null)
            {
                return Json(new {success = false, message = "Something Wrong Happended"});
            }

            string webRootPath = _hostEnvironment.WebRootPath;

            string imagePath = Path.Combine(webRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _UoW.Product.Remove(obj);
            _UoW.Save();
            return Json(new {success = true, message = "Successful"});
        }
    }
}