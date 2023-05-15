using Counseling.Business.Abstract;
using Counseling.Core;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Counseling.MVC.Methods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]


    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly UserManager<User> _userManager;
        private readonly IImageService _imageService;

        public ClientController(IClientService clientService, UserManager<User> userManager, IImageService imageService)
        {
            _clientService = clientService;
            _userManager = userManager;
            _imageService = imageService;
        }

        #region Listing
        public async Task<IActionResult> Index()
        {

            var clients = await _clientService.GetAllAsync();
            var users = await _userManager.GetUsersInRoleAsync("Client");


            List<ClientUserViewModel> clientUserViewModels = clients.Select(x => new ClientUserViewModel
            {
                ClientId = x.Id,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                UserName = x.User.UserName,
                DateOfBirth = x.User.DateOfBirth,
                DateOfRegistration = x.User.DateOfRegistration,
                Gender = x.User.Gender,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber
            }).ToList();

            return View(clientUserViewModels);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            ClientAddViewModel clientAddViewModel = new ClientAddViewModel();
            clientAddViewModel.GenderList = GeneralMethods.GenderList();
            return View(clientAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientAddViewModel clientAddViewModel)
        {
            if(ModelState.IsValid)
            {
                var imageName = clientAddViewModel.ProfilePic.FileName;
                int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                User user = new User
                {
                    FirstName = clientAddViewModel.FirstName,
                    LastName = clientAddViewModel.LastName,
                    UserName = clientAddViewModel.UserName,
                    NormalizedName = (clientAddViewModel.FirstName + clientAddViewModel.LastName),
                    Gender = clientAddViewModel.Gender,
                    Email = clientAddViewModel.Email,
                    DateOfBirth = clientAddViewModel.DateOfBirth,
                    DateOfRegistration = DateTime.Now,
                    Address = clientAddViewModel.Address,
                    PhoneNumber = clientAddViewModel.PhoneNumber,
                    
                    Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(clientAddViewModel.ProfilePic, "profilepics/clients", ImageNameRepeatCount),
                    }
                };
                var result = await _userManager.CreateAsync(user, clientAddViewModel.Password);
                if(result.Succeeded)
                {
                    Client client = new Client
                    {
                        IsApproved = true,
                        UserId = user.Id,
                        Url = Jobs.GetUrl(clientAddViewModel.UserName)
                    };
                    await _clientService.CreateAsync(client);
                    await _userManager.AddToRoleAsync(user, "Client");
                    return RedirectToAction("Index", "Client");
                }
            }
            clientAddViewModel.GenderList = GeneralMethods.GenderList(clientAddViewModel.Gender);
            return View(clientAddViewModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetById(id);
            var user = await _userManager.FindByIdAsync(client.UserId);
            var image = await _imageService.GetImageByUserIdAsync(user.Id);
            var clientUpdateViewModel = new ClientUpdateViewModel
            {
                ClientId = client.Id,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = user.Gender,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                GenderList = GeneralMethods.GenderList(user.Gender),
                ProfilPictureUrl = image.Url,
                IsApproved = client.IsApproved,
                Address = user.Address,

            };
            return View(clientUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ClientUpdateViewModel clientUpdateViewModel)
        {
            var user = await _userManager.FindByIdAsync(clientUpdateViewModel.UserId);
            var client = await _clientService.GetById(clientUpdateViewModel.ClientId);
            var image = await _imageService.GetImageByUserIdAsync(user.Id);
            if (ModelState.IsValid)
            {
                user.UserName = clientUpdateViewModel.UserName;
                user.LastName = clientUpdateViewModel.LastName;
                user.Email = clientUpdateViewModel.Email;
                user.Gender = clientUpdateViewModel.Gender;
                user.DateOfBirth = clientUpdateViewModel.DateOfBirth;
                user.FirstName = clientUpdateViewModel.FirstName;
                user.NormalizedName = (clientUpdateViewModel.FirstName + clientUpdateViewModel.LastName).ToUpper();
                user.PhoneNumber = clientUpdateViewModel.PhoneNumber;
                client.IsApproved = clientUpdateViewModel.IsApproved;
                client.Url = Jobs.GetUrl(clientUpdateViewModel.UserName);
                if (clientUpdateViewModel.ProfilePic != null)
                {

                    var imageName = clientUpdateViewModel.ProfilePic.FileName;
                    int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                    user.Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(clientUpdateViewModel.ProfilePic, "profilepics/clients", ImageNameRepeatCount)
                    };
                }
                await _userManager.UpdateAsync(user);
                _clientService.Update(client);
                return RedirectToAction("Index");
            }
            clientUpdateViewModel.ProfilPictureUrl = image.Url;
            clientUpdateViewModel.GenderList = GeneralMethods.GenderList(user.Gender);
            return View(clientUpdateViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientService.GetById(id);
            var user = await _userManager.FindByIdAsync(client.UserId);
            if (user == null || client == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Client");
        }
        #endregion

    }
}
