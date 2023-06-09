﻿using Counseling.Business.Abstract;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models;
using Counseling.MVC.Models.ViewModels;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Counseling.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IServiceService _serviceService;
        private ITherapistService _therapistService;
        private UserManager<User> _userManager;
        private ICategoryService _categoryService;


        public HomeController(IServiceService serviceService, ITherapistService therapistService, UserManager<User> userManager, ICategoryService categoryService)
        {
            _serviceService = serviceService;
            _therapistService = therapistService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> services = await _serviceService.GetAllServiceWithFullDataAsync(true);
            List<Category> categories = await _categoryService.GetAllAsync();
            List<ServiceModel> serviceModels = new List<ServiceModel>();
            if(services.Count> 0)
            {
                serviceModels = services.Select(s => new ServiceModel
                {
                    ServiceId = s.Id,
                    TherapistId = s.TherapistId,
                    IsApproved = s.IsApproved,
                    IsConfirmed = s.IsConfirmed,
                    Price = s.Price,
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
                    Therapist = s.Therapist,
                    User = s.Therapist.User,
                    ImageUrl = s.Therapist.User.Image.Url,
                    Url = s.Url


                }).ToList();

            }
            ServiceModelList serviceModelList = new ServiceModelList
            {
                ServiceModels = serviceModels,
                Categories = categories
            };
            return View(serviceModelList);
        }
    }
}