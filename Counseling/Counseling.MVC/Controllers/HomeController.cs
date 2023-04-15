using Counseling.Business.Abstract;
using Counseling.Entity.Entity;
using Counseling.MVC.Models;
using Counseling.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Counseling.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IServiceService _serviceService;

        public HomeController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            // tüm detaylarıyla service i getirecek method lazım
            List<Service> services = await _serviceService.GetAllServiceWithFullDataAsync(true);
            List<ServiceModel> serviceModels = new List<ServiceModel>();
            serviceModels = services.Select(s => new ServiceModel
            {
                Id = s.Id,
                IsApproved = s.IsApproved,
                IsConfirmed = s.IsConfirmed,
                Price = s.Price,
                ServiceCategories = s.ServiceCategories
                .Select(sc => new ServiceCategory
                {
                    Category = new Category
                    {
                        Id = sc.CategoryId,
                        Description = sc.Category.Description,
                        IsDeleted = sc.Category.IsDeleted,
                        IsApproved = sc.Category.IsApproved,
                        Name = sc.Category.Name,
                        Url = sc.Category.Url
                    },
                    CategoryId = sc.Category.Id,
                    Service = new Service
                    {
                        Id = sc.Service.Id,
                        Price = sc.Service.Price,

                    },
                    ServiceId = sc.Service.Id

                }
                ).ToList(),
                ServiceTherapist = new ServiceTherapist
                {
                    ServiceId = s.ServiceTherapist.ServiceId,
                    TherapistId = s.TherapistId
                },
                TherapistId =s.TherapistId,
                Url=s.Url
                

            }).ToList();

            return View(serviceModels);
        }
    }
}