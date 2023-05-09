using Counseling.Business.Abstract;
using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels.ReservationModels;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Counseling.MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IClientService _clientService;
        private readonly UserManager<User> _userManager;
        private readonly IReservationService _reservationService;
        private readonly ITherapistService _therapistService;
        public ReservationController(IServiceService serviceService, IClientService clientService, UserManager<User> userManager, IReservationService reservationService, ITherapistService therapistService)
        {
            _serviceService = serviceService;
            _clientService = clientService;
            _userManager = userManager;
            _reservationService = reservationService;
            _therapistService = therapistService;
        }

        public async Task<IActionResult> Index(int id)
        {
            // userName ile cient ve therpaist id getirecek method yazılacak
            string roleName = User.IsInRole("Therapist") ? "therapist" : "client";
            int? userId = null;
            string userName = User.Identity.Name;
            if (roleName == "therapist")
            {
                userId = await _therapistService.GetTherapistIdByUserName(userName);
            }
            else
            {
                userId = await _clientService.GetClientIdByUserNameAsync(userName);
            }
            var reservations = _reservationService.GetAllReservations(null, roleName, userId);
            List<ReservationViewModel> reservationViewModels = reservations.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                TherapistId = r.TherapistId,
                ServiceId=r.ServiceId,
                Price = r.Price,
                ReservationDate = r.ReservationDate,
                ClientId = r.ClientId,
                Email = r.ClientServices
                .Select(r => r.Client.User.Email).FirstOrDefault(),
                ClientName = r.ClientServices
                .Select(r=> r.Client.User.FirstName+ " " + r.Client.User.LastName).FirstOrDefault(),
                ClientPhoneNumber= r.ClientServices
                .Select(r => r.Client.User.PhoneNumber).FirstOrDefault()
                
            }).ToList();
            return View(reservationViewModels);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var service = await _serviceService.GetServiceWithFullDataById(id);
            if (!User.IsInRole("Client"))
            {
                return RedirectToAction("Register", "Account");
            }
            string userName = User.Identity.Name;
            var client = await _clientService.GetClientByUserName(userName);
            var reservationAddViewModel = new ReservationAddViewModel
            {
                ClientId = client.Id,
                ServiceId = service.Id,
                Price = service.Price,
                User = await _userManager.FindByNameAsync(userName)
            };
            return View(reservationAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationAddViewModel reservationAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = await _serviceService.GetServiceWithFullDataById(reservationAddViewModel.ServiceId);
                var reservation = new Reservation
                {
                    IsConfirmed = false,
                    Price = reservationAddViewModel.Price,
                    ReservationDate = reservationAddViewModel.ReservationDate,
                    ClientId=reservationAddViewModel.ClientId,
                    ServiceId=service.Id,
                    TherapistId=service.TherapistId,
                    ClientServices = new List<ClientService>
                    {
                        new ClientService
                        {
                            
                            ClientId = reservationAddViewModel.ClientId,
                            ServiceId = reservationAddViewModel.ServiceId
                        }

                    },
                    ClientTherapists = new List<ClientTherapist>
                    {
                        new ClientTherapist
                        {
                            ClientId = reservationAddViewModel.ClientId,
                            TherapistId = service.TherapistId
                        }
                    }
                };
                await _reservationService.CretaeAsync(reservation);
                return RedirectToAction("Index", "Home");

            }
            return View(reservationAddViewModel);
        }
        #endregion
    }
}
