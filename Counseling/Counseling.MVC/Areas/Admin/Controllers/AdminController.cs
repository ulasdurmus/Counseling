using Counseling.Business.Abstract;
using Counseling.Core;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IImageService _imageService;

        public AdminController(UserManager<User> userManager, IImageService imageService)
        {
            _userManager = userManager;
            _imageService = imageService;
        }

        #region Listing
        public async Task<IActionResult> Index()
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            List<AdminViewModel> adminList = admins.Select(a => new AdminViewModel
            {
                UserId = a.Id,
                UserName = a.UserName,
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
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Cinsiyet Seçiniz",
                Selected = true,
                Disabled = true

            });
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın"
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek"
            });

            AdminAddViewModel adminAddViewModel = new AdminAddViewModel();
            adminAddViewModel.GenderSelectList = genderList;
            return View(adminAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminAddViewModel adminAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var imageName = adminAddViewModel.ProfilePic.FileName;
                int ImageNameRepeatCount = _imageService.CheckImageName(imageName);

                User user = new User
                {
                    FirstName = adminAddViewModel.FirstName,
                    LastName = adminAddViewModel.LastName,
                    UserName = adminAddViewModel.UserName,
                    NormalizedName = (adminAddViewModel.FirstName + adminAddViewModel.LastName).ToUpper(),
                    Gender = adminAddViewModel.Gender,
                    Email = adminAddViewModel.Email,
                    DateOfBirth = adminAddViewModel.DateOfBirth,
                    DateOfRegistration = DateTime.Now,
                    Address = adminAddViewModel.Address,
                    Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(adminAddViewModel.ProfilePic, "profilepics/admins", ImageNameRepeatCount)
                    }
                };
                var result = await _userManager.CreateAsync(user, adminAddViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View(adminAddViewModel);
        }

        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var admin = await _userManager.FindByIdAsync(id);
            //var images = await _imageService.GetAllAsync();
            var images = await _imageService.GetByIdAsync(admin.Image.Id);

            List<SelectListItem> genderList = new List<SelectListItem>();
           
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = admin.Gender=="Kadın" ? true : false,
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = admin.Gender == "Erkek" ? true : false,
            });
            var adminUpdataViewModel = new AdminUpdateViewModel
            {
                UserId= admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                UserName = admin.UserName,
                Gender = admin.Gender,
                Email = admin.Email,
                DateOfBirth = admin.DateOfBirth,
                PhoneNumber = admin.PhoneNumber,
                GenderSelectList = genderList,
                ProfilPictureUrl = admin.Image.Url
                
            };

            return View(adminUpdataViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdminUpdateViewModel adminUpdateViewModel)
        {
            var image = await _imageService.GetAllAsync();
            User user = await _userManager.FindByIdAsync(adminUpdateViewModel.UserId);
            List<SelectListItem> genderList = new List<SelectListItem>();

            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false,
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false,
            });
            // Identitiy change passwpord methodunu kullan
            if (ModelState.IsValid)
            {
                user.UserName = adminUpdateViewModel.UserName;
                user.LastName = adminUpdateViewModel.LastName;
                user.Email = adminUpdateViewModel.Email;
                user.Gender = adminUpdateViewModel.Gender;
                user.DateOfBirth = adminUpdateViewModel.DateOfBirth;
                user.FirstName = adminUpdateViewModel.FirstName;
                user.NormalizedName = (adminUpdateViewModel.FirstName+adminUpdateViewModel.LastName).ToUpper();
                user.PhoneNumber = adminUpdateViewModel.PhoneNumber;

                if (adminUpdateViewModel.ProfilePic != null)
                {
                    
                    var imageName = adminUpdateViewModel.ProfilePic.FileName;
                    int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                    user.Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(adminUpdateViewModel.ProfilePic, "profilepics/admins", ImageNameRepeatCount)
                    };
                }
                
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            adminUpdateViewModel.ProfilPictureUrl = user.Image.Url;
            adminUpdateViewModel.GenderSelectList = genderList;
            return View (adminUpdateViewModel);

        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                User user = await _userManager.FindByEmailAsync(id);


                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
