using System.Diagnostics;
using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNet_MVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _UoW;

        public HomeController(ILogger<HomeController> logger,
            IUnitOfWork uoW)
        {
            _logger = logger;
            _UoW = uoW;
        }

        public IActionResult Index()
        {
            var bookList = _UoW.Product.GetAll(includeProperties: "Category,CoverType");
            return View(bookList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}