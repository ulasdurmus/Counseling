using Counseling.Business.Abstract;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
