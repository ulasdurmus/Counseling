using Counseling.Business.Abstract;
using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels.ReservationModels;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IClientService _clientService;
        private readonly UserManager<User> _userManager;
        private readonly IReservationService _reservationService;
        public ReservationController(IServiceService serviceService, IClientService clientService, UserManager<User> userManager, IReservationService reservationService)
        {
            _serviceService = serviceService;
            _clientService = clientService;
            _userManager = userManager;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var service = await _serviceService.GetServiceWithFullDataById(id);
            if(!User.IsInRole("Client"))
            {
                return RedirectToAction("Register","Account");
            }
            string userName = User.Identity.Name;
            var client = await _clientService.GetClientByUserName(userName);
            var reservationAddViewModel = new ReservationAddViewModel
            {
                ClientId = client.Id,
                ServiceId = service.Id,
                Price = service.Price,
                User =await _userManager.FindByNameAsync(userName)
            };
            return  View(reservationAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationAddViewModel reservationAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = await _serviceService.GetServiceWithFullDataById(reservationAddViewModel.ServiceId);
                var reservation = new Reservation
                {
                    ClientId = reservationAddViewModel.ClientId,
                    IsConfirmed = false,
                    Price = reservationAddViewModel.Price,
                    ReservationDate = reservationAddViewModel.ReservationDate,
                    ClientService = new ClientService
                    {
                        ClientId = reservationAddViewModel.ClientId,
                        ServiceId = reservationAddViewModel.ServiceId
                    },
                    ClientTherapist = new ClientTherapist
                    {
                        ClientId = reservationAddViewModel.ClientId,
                        TherapistId = service.TherapistId
                    }
                };
                await _reservationService.CretaeAsync(reservation);

            }
            return View();
        } 
        #endregion
    }
}
