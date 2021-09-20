using System;
using System.Linq;
using DotNet_MVC.Application.Common;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Domain.Static;
using DotNet_MVC.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.Role_Admin + "," + StaticDetail.Role_Employee)]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUser.Include(u => u.Company).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new {data = userList});
        }

        [HttpPost]
        public IActionResult RestrictUser([FromBody] string id)
        {
            var obj = _db.ApplicationUser.FirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Something Happened!"});
            }

            obj.LockoutEnd = DateTime.Now.AddHours(1);

            _db.SaveChanges();
            return Json(new {success = true, message = "User Restricted"});
        }

        [HttpPost]
        public IActionResult UnrestrictUser([FromBody] string id)
        {
            var obj = _db.ApplicationUser.FirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return Json(new {success = false, message = "Something Happened!"});
            }

            obj.LockoutEnd = DateTime.Now;

            _db.SaveChanges();
            return Json(new {success = true, message = "User Unrestricted"});
        }
    }
}