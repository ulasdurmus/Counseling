using Counseling.Entity.Entity.Identitiy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            //Super admin giriş yapmış gibi gösterip bilgilerine erişiriz.
            var admins =await _userManager.GetUsersInRoleAsync("SuperAdmin");
            foreach (var admin in admins)
            {
                ViewBag.Name = admin.FirstName + " " +admin.LastName;
                ViewBag.UserId = admin.Id;
            }
            return View();
        }
    }
}
