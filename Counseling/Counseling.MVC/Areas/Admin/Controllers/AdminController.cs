using Counseling.Core;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        #region Listing
        public async Task<IActionResult> Index()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            List<AdminViewModel> adminList = admins.Select(a => new AdminViewModel
            {
                UserName= a.UserName,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Gender = a.Gender,
                Email = a.Email,
                DateOfBirth = a.DateOfBirth,
                DateOfRegistration = a.DateOfRegistration,
                PhoneNumber = a.PhoneNumber
            }).ToList();
            return View(adminList);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminAddViewModel adminAddViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = adminAddViewModel.FirstName,
                    LastName = adminAddViewModel.LastName,
                    //NormalizedName = (adminAddViewModel.FirstName + adminAddViewModel.LastName).ToUpper(),
                    Gender = adminAddViewModel.Gender,
                    Email = adminAddViewModel.Email,
                    DateOfBirth = adminAddViewModel.DateOfBirth,
                    DateOfRegistration = DateTime.Now,
                    Image = new Image
                    {
                        IsApproved = true,
                        Url= Jobs.UploadImage(adminAddViewModel.ProfilePic, "profilepics/admins")
                    }
                };
                var result = await _userManager.CreateAsync(user, adminAddViewModel.Password);
                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View(adminAddViewModel);
        }
        [HttpPost]
        public IActionResult Create2(AdminAddViewModel adminAddViewModel, IFormFile ProfilePic)
        {
            return View();
        }
        #endregion
    }
}
