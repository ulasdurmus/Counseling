using Counseling.Business.Abstract;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TherapistController : Controller
    {
        private readonly ITherapistService _therapistService;
        private readonly UserManager<User> _userManager;

        public TherapistController(ITherapistService therapistService, UserManager<User> userManager)
        {
            _therapistService = therapistService;
            _userManager = userManager;
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
            TherapistAddViewModel therapistAddViewModel = new TherapistAddViewModel();
            therapistAddViewModel.GenderList= genderList;
            return View(therapistAddViewModel);
        }
        #endregion
    }
}
