using Counseling.Business.Abstract;
using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Models.ViewModels.ReservationModels;
using Counseling.MVC.Models.ViewModels.ServiceModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var reservations = _reservationService.GetAllReservations(false, roleName, userId);
            List<ReservationViewModel> reservationViewModels = reservations.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                TherapistId = r.TherapistId,
                ServiceId=r.ServiceId,
                Price = r.Price,
                ReservationDate = r.ReservationDate,
                ClientId = r.ClientId,
                IsConfirmed=r.IsConfirmed,
                TherapistEmail=r.ClientTherapists.Select(r=> r.Therapist.User.Email).FirstOrDefault(),
                TherapistPhoneNumber=r.ClientTherapists.Select(r=> r.Therapist.User.PhoneNumber).FirstOrDefault(),
                TherapistName=r.ClientTherapists.Select(r=> r.Therapist.User.FirstName + " " + r.Therapist.User.LastName).FirstOrDefault(),
                ClientEmail = r.ClientServices.Select(r => r.Client.User.Email).FirstOrDefault(),
                ClientName = r.ClientServices.Select(r=> r.Client.User.FirstName+ " " + r.Client.User.LastName).FirstOrDefault(),
                ClientPhoneNumber= r.ClientServices.Select(r => r.Client.User.PhoneNumber).FirstOrDefault()
                
            }).ToList();
            var reservationListViewModel = new ReservationListViewModel
            {
                ReservationViewModels = reservationViewModels,
                RoleName = roleName,
            };
            return View(reservationListViewModel);
        }

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var service = await _serviceService.GetServiceWithFullDataById(id);
            if (!User.IsInRole("Client"))
            {
                return RedirectToAction("Login", "Account");
            }
            string userName = User.Identity.Name;
            var client = await _clientService.GetClientByUserName(userName);
            var hours = await _reservationService.GetAllReservationHoursAsync();
            var reservationAddViewModel = new ReservationAddViewModel
            {
                ReservationHours = hours,
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
                string hour = await _reservationService.GetHourValueByIdAsync(reservationAddViewModel.ReservationHourId);
                DateTime date = DateTime.Parse((reservationAddViewModel.ReservationDate.ToString() + " " + hour.ToString()).ToString());
                DateTime reservatonDateTime;
                if(DateTime.TryParse(reservationAddViewModel.ReservationDate.ToString() + " " + hour.ToString(),out reservatonDateTime))
                {
                    date = reservatonDateTime;
                }
                
                var reservation = new Reservation
                {
                    IsConfirmed = false,
                    Price = reservationAddViewModel.Price,
                    //ReservationDate = ((reservationAddViewModel.ReservationDate).Date, Convert.ToDateTime(reservationAddViewModel.ReservationHourId)) ,
                    //ReservationDate = Convert.ToDateTime(dateTime),
                    ReservationDate = date,
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
            reservationAddViewModel.ReservationHours= await _reservationService.GetAllReservationHoursAsync();
            return View(reservationAddViewModel);
        }
        #endregion
        #region CheckStatus
        public async Task<IActionResult> UpdateIsConfirmed(int id)
        {
            Reservation reservation = await _reservationService.GetByIdAsync(id);
            if(reservation == null)
            {
                return NotFound();
            }
            reservation.IsConfirmed= !reservation.IsConfirmed;
            _reservationService.Update(reservation);
            return RedirectToAction("Index");
        }
        #endregion
        #region Checkout
        [HttpGet]
        public async Task<IActionResult> Checkout(int id)
        {
            // id = reservationId
            var userName = _userManager.FindByNameAsync(User.Identity.Name);
            var reservation = await _reservationService.GetReservationFullDataAsync(id);
            ReservationPaymentviewModel reserationPaymentViewModel = new ReservationPaymentviewModel
            {
                Id = id,
                ClientFirstName = reservation.ClientServices.Select(r => r.Client.User.FirstName).FirstOrDefault(),
                ClientLastName = reservation.ClientServices.Select(r => r.Client.User.LastName).FirstOrDefault(),
                ClientMail = reservation.ClientServices.Select(r => r.Client.User.Email).FirstOrDefault(),
                ClientPhoneNumber = reservation.ClientServices.Select(r => r.Client.User.PhoneNumber).FirstOrDefault(),
                TherapistName = reservation.ClientTherapists.Select(r => r.Therapist.User.FirstName + " " + r.Therapist.User.LastName).FirstOrDefault(),
                TherapistMail = reservation.ClientTherapists.Select(r => r.Therapist.User.Email).FirstOrDefault(),
                TherapistPhoneNumber = reservation.ClientTherapists.Select(r => r.Therapist.User.PhoneNumber).FirstOrDefault(),
                ReservationDate = reservation.ReservationDate,
                Price = reservation.Price

            };
            return View(reserationPaymentViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Checkout(ReservationPaymentviewModel reservationPaymentViewModel)
        {
            if (ModelState.IsValid)
            {
                var reservation = await _reservationService.GetReservationFullDataAsync(reservationPaymentViewModel.Id);
                if (!CardNumberControl(reservationPaymentViewModel.CardNumber))
                {
                    return View(reservationPaymentViewModel);
                }
                Payment payment = PaymentProcess(reservationPaymentViewModel);
                if (payment.Status == "success")
                {
                    reservation.IsPaid = true;
                    _reservationService.Update(reservation);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(reservationPaymentViewModel);
        }
        #endregion

        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            #region Açıklamalar
            /* -cardNumber'ı boşluk ve tire'den arındıracağız.
             * -cardNumber uzunluk kontrolünü yapacağız.
             * -Sayısal değer kontrolü yapacağız.
             * -Luhn algoritmasına uygunluğunu test edeceğiz
             */
            #endregion
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }
        private Payment PaymentProcess(ReservationPaymentviewModel reservationPaymentViewModel)
        {
            #region Payment Options Created
            Options options = new Options();
            options.ApiKey = "sandbox-A7BCyFsZE4RiKRgPFsK0SQvGUoUxT5XG";
            options.SecretKey = "sandbox-8C8S83dLKs7USUvSR05xaFKYGMBtBuPC";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            #endregion
            #region Create Payment Request
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(reservationPaymentViewModel.Price).ToString(),
                PaidPrice = Convert.ToInt32(reservationPaymentViewModel.Price).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = reservationPaymentViewModel.Id.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = reservationPaymentViewModel.CardName,
                    CardNumber = reservationPaymentViewModel.CardNumber,
                    ExpireMonth = reservationPaymentViewModel.ExpirationMonth,
                    ExpireYear = reservationPaymentViewModel.ExpirationYear,
                    Cvc = reservationPaymentViewModel.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY999",
                    Name = reservationPaymentViewModel.ClientFirstName,
                    Surname = reservationPaymentViewModel.ClientLastName,
                    GsmNumber = reservationPaymentViewModel.ClientPhoneNumber,
                    Email = reservationPaymentViewModel.ClientMail,
                    IdentityNumber = "87955588899",
                    RegistrationAddress = reservationPaymentViewModel.Address,
                    Ip = "84.99.155.212",
                    City = reservationPaymentViewModel.City,
                    Country = "Türkiye",
                    ZipCode = "34700"
                },
                ShippingAddress = new Address
                {
                    ContactName = reservationPaymentViewModel.ClientFirstName + " " + reservationPaymentViewModel.ClientLastName,
                    City = reservationPaymentViewModel.City,
                    Country = "Türkiye",
                    Description = reservationPaymentViewModel.Address
                },
                BillingAddress = new Address
                {
                    ContactName = reservationPaymentViewModel.ClientFirstName + " " + reservationPaymentViewModel.ClientLastName,
                    City = reservationPaymentViewModel.City,
                    Country = "Türkiye",
                    Description = reservationPaymentViewModel.Address
                }
            };
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            
                basketItem = new BasketItem
                {
                    Id = reservationPaymentViewModel.Id.ToString(),
                    Name = reservationPaymentViewModel.TherapistName.ToString(),
                    Category1 = "Service",
                    ItemType = BasketItemType.VIRTUAL.ToString(),
                    Price = Convert.ToInt32(reservationPaymentViewModel.Price).ToString()
                };
                basketItems.Add(basketItem);
            
            request.BasketItems = basketItems;
            #endregion
            Payment payment = Payment.Create(request, options);
            return payment;
        }
    }
}
