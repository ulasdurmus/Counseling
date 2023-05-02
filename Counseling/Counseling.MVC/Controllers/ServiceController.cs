using Counseling.Business.Abstract;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ITherapistService _therapistService;
        private readonly UserManager<User> _userManager;

        public ServiceController(IServiceService serviceService, ITherapistService therapistService, UserManager<User> userManager)
        {
            _serviceService = serviceService;
            _therapistService = therapistService;
            _userManager = userManager;
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
                IsApproved = s.IsApproved,
                Price = s.Price,
                Url = s.Url,
                TherapistId = s.Id,
                ServiceCategories = s.ServiceCategories.ToList()
            }).ToList();

            
            return View(serviceModel);
        }
        #endregion
    }
}
