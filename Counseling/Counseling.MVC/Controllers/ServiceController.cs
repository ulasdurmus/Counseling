using Counseling.Business.Abstract;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Controllers
{
    [Authorize(Roles ="Therapist")]
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
        public async Task<IActionResult> Index(string id=null)
        {
            string userName = User.Identity.Name;
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
                Description = s.Description,
                Categories = s.ServiceCategories
                .Select(sc => new Category
                {

                    Id = sc.CategoryId,
                    Description = sc.Category.Description,
                    IsDeleted = sc.Category.IsDeleted,
                    IsApproved = sc.Category.IsApproved,
                    Name = sc.Category.Name,
                    Url = sc.Category.Url
                }).ToList(),
            }).ToList();

            
            return View(serviceModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Service service = await _serviceService.GetServiceWithFullDataById(id);
            ServiceUpdateViewModel serviceUpdateViewModel = new ServiceUpdateViewModel
            {
                SelectedCategories = service.ServiceCategories.Select(sc => sc.Category.Id).ToArray(),
                IsApproved = service.IsApproved,
                Price = service.Price,
                Url = service.Url,
                Description = service.Description
                
            };
            serviceUpdateViewModel.UserName = User.Identity.Name;
            serviceUpdateViewModel.ServiceId = id;
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
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceUpdateViewModel serviceUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                var service = await _serviceService.GetServiceWithFullDataById(serviceUpdateViewModel.ServiceId);
                service.Price = serviceUpdateViewModel.Price;
                service.Description = serviceUpdateViewModel.Description;
                service.IsApproved = serviceUpdateViewModel.IsApproved;
                service.ServiceCategories = serviceUpdateViewModel.SelectedCategories.Select(sc => new ServiceCategory
                {
                    CategoryId = sc,
                    ServiceId = serviceUpdateViewModel.ServiceId
                }).ToList();
                _serviceService.Update(service);
                return RedirectToAction("Index");
            }
            return View(serviceUpdateViewModel);
        }
        #endregion
        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceService.GetServiceWithFullDataById(id);
            _serviceService.Delete(service);
            return RedirectToAction("Index");
        }
        #endregion
        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var serviceAddViewModel = new ServiceAddViewModels
            {
                Categories = await _categoryService.GetAllAsync()
            };
            return View(serviceAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceAddViewModels serviceAddViewModel)
        {
            
            if(ModelState.IsValid)
            {
                Therapist therapist = await _therapistService.GetTherapistFullDataByUserName(User.Identity.Name);
                var service = new Service
                {
                    Therapist=therapist,
                    IsApproved = serviceAddViewModel.IsApproved,
                    Price = serviceAddViewModel.Price,
                    TherapistId = therapist.Id,
                    Url = "service" + User.Identity.Name,
                    Description = serviceAddViewModel.Description
                };
                await _serviceService.CreateServiceWithFullData(service, serviceAddViewModel.SelectedCategories);
                
                return RedirectToAction("Index");
            }
            serviceAddViewModel.Categories = await _categoryService.GetAllAsync();
            return View(serviceAddViewModel);
        }
        #endregion
        
    }
}
