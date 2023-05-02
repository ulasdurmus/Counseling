using Counseling.Business.Abstract;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ITherapistService _therapistService;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;

        public ServiceController(IServiceService serviceService, ITherapistService therapistService, UserManager<User> userManager, ICategoryService categoryService)
        {
            _serviceService = serviceService;
            _therapistService = therapistService;
            _userManager = userManager;
            _categoryService = categoryService;
        }
        #region Listeleme
        public async Task<IActionResult> Index(string id)
        {
            string userName = id;
            var therapist = await _therapistService.GetTherapistFullDataByUserName(userName);
            var services = await _serviceService.GetServicesWithFullDataByTherapistIdAsync(therapist.Id);
            var user = await _userManager.FindByNameAsync(userName);
            List<ServiceModel> serviceModel = services.Select(s => new ServiceModel
            {
                ServiceId = s.Id,
                IsApproved = s.IsApproved,
                Price = s.Price,
                Url = s.Url,
                TherapistId = s.TherapistId,
                ServiceCategories = s.ServiceCategories.ToList()
            }).ToList();

            
            return View(serviceModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Service service = await _serviceService.GetByIdAsync(id);
            ServiceUpdateViewModel serviceUpdateViewModel = new ServiceUpdateViewModel
            {
                SelectedCategories = service.ServiceCategories.Select(sc => sc.Category.Id).ToArray(),
                IsApproved = service.IsApproved,
                Price = service.Price,
                Url = service.Url,
                TherapistId = service.TherapistId,
            };

            var categories = await _categoryService.GetAllAsync();
            serviceUpdateViewModel.Categories = categories.Select(c=> new Category
            {
                Id = c.Id,
                Description = c.Description,
                IsApproved = c.IsApproved,
                IsDeleted= c.IsDeleted,
                Name = c.Name,
                Url =c.Url
            }).ToList();
            return View(serviceUpdateViewModel);
        }
        #endregion
    }
}
