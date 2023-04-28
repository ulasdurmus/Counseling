using Counseling.Business.Abstract;
using Counseling.Core;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Counseling.MVC.Methods;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TherapistController : Controller
    {
        private readonly ITherapistService _therapistService;
        private readonly UserManager<User> _userManager;
        private readonly IImageService _imageService;

        public TherapistController(ITherapistService therapistService, UserManager<User> userManager, IImageService imageService)
        {
            _therapistService = therapistService;
            _userManager = userManager;
            _imageService = imageService;
        }

        #region Listing
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.FindByIdAsync("b7082603-2d69-4adc-bc4e-1e294a75cd5a");

            var therapists = await _therapistService.GetAllAsync();
            var users = await _userManager.GetUsersInRoleAsync("Therapist");
            //var userTherapist = _therapistService.GetAllEntityAndUserInformation(therapists, users);


            List<TherapistUserViewModel> threapistUserViewModel = therapists.Select(x => new TherapistUserViewModel
            {
                TherapistId = x.Id,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                UserName = x.User.UserName,
                DateOfBirth = x.User.DateOfBirth,
                DateOfRegistration=x.User.DateOfRegistration,
                Gender = x.User.Gender,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber
            }).ToList();

            return View(threapistUserViewModel);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            TherapistAddViewModel therapistAddViewModel = new TherapistAddViewModel();
            therapistAddViewModel.GenderList= GeneralMethods.GenderList();
            return View(therapistAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TherapistAddViewModel therapistAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var imageName = therapistAddViewModel.ProfilePic.FileName;
                int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                User user = new User
                {
                    FirstName = therapistAddViewModel.FirstName,
                    LastName = therapistAddViewModel.LastName,
                    UserName = therapistAddViewModel.UserName,
                    NormalizedName = (therapistAddViewModel.FirstName + therapistAddViewModel.LastName),
                    Gender = therapistAddViewModel.Gender,
                    Email = therapistAddViewModel.Email,
                    DateOfBirth = therapistAddViewModel.DateOfBirth,
                    DateOfRegistration = DateTime.Now,
                    Address = therapistAddViewModel.Address,
                    PhoneNumber = therapistAddViewModel.PhoneNumber,
                    Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(therapistAddViewModel.ProfilePic, "profilepics/therapists", ImageNameRepeatCount),
                    }
                };
                var result = await _userManager.CreateAsync(user, therapistAddViewModel.Password);
                if (result.Succeeded)
                {
                    Therapist therapist = new Therapist
                    {
                        Description = therapistAddViewModel.Description,
                        IsApproved = true,
                        UserId = user.Id,
                        Url= Jobs.GetUrl(therapistAddViewModel.UserName)

                    };
                    await _therapistService.CreateAsync(therapist);
                    await _userManager.AddToRoleAsync(user, "Therapist");
                    return RedirectToAction("Index", "Therapist");
                }
                
            }
            therapistAddViewModel.GenderList = GeneralMethods.GenderList();
            return View(therapistAddViewModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var therapist = await _therapistService.GetByIdAsync(id);
            var image = await _imageService.GetAllAsync();
            var user = await _userManager.FindByIdAsync(therapist.UserId);
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
            var therapistUpdateViewModel = new TherapistUpdateViewModel
            {
                TherapistId = therapist.Id,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = user.Gender,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                GenderList = genderList,
                ProfilPictureUrl = user.Image.Url,
                Description = therapist.Description,
                IsApproved = therapist.IsApproved,
                Address = user.Address,
                

            };
            return View(therapistUpdateViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(TherapistUpdateViewModel therapistUpdateViewModel)
        {
            var user = await _userManager.FindByIdAsync(therapistUpdateViewModel.UserId);
            var therapist = await _therapistService.GetByIdAsync(therapistUpdateViewModel.TherapistId);
            var images = await _imageService.GetAllAsync();
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
            if (ModelState.IsValid)
            {
                user.UserName = therapistUpdateViewModel.UserName;
                user.LastName = therapistUpdateViewModel.LastName;
                user.Email = therapistUpdateViewModel.Email;
                user.Gender = therapistUpdateViewModel.Gender;
                user.DateOfBirth = therapistUpdateViewModel.DateOfBirth;
                user.FirstName = therapistUpdateViewModel.FirstName;
                user.NormalizedName = (therapistUpdateViewModel.FirstName + therapistUpdateViewModel.LastName).ToUpper();
                user.PhoneNumber = therapistUpdateViewModel.PhoneNumber;
                therapist.Description = therapistUpdateViewModel.Description;
                therapist.IsApproved = therapistUpdateViewModel.IsApproved;
                therapist.Url = Jobs.GetUrl(therapistUpdateViewModel.UserName);

                if (therapistUpdateViewModel.ProfilePic != null)
                {

                    var imageName = therapistUpdateViewModel.ProfilePic.FileName;
                    int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                    user.Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(therapistUpdateViewModel.ProfilePic, "profilepics/therapists", ImageNameRepeatCount)
                    };
                }
                await _userManager.UpdateAsync(user);
                _therapistService.Update(therapist);
                return RedirectToAction("Index");
            }
            therapistUpdateViewModel.ProfilPictureUrl = user.Image.Url;
            therapistUpdateViewModel.GenderList = genderList;
            return View(therapistUpdateViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var therapist =await  _therapistService.GetByIdAsync(id);
            var user = await _userManager.FindByIdAsync(therapist.UserId);
            if(user == null || therapist == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            _therapistService.Delete(therapist);
            return RedirectToAction("Index","Therapist");
        }
        #endregion
    }
}
