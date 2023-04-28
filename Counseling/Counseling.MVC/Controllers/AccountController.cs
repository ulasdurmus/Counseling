using Counseling.Business.Abstract;
using Counseling.Business.Concrete;
using Counseling.Core;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Counseling.MVC.Areas.Admin.Models.ViewModels;
using Counseling.MVC.Methods;
using Counseling.MVC.Models.ViewModels.AccountModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Counseling.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICategoryService _categoryService;
        private readonly ITherapistService _therapistService;
        private readonly IImageService _imageService;
        private readonly IClientService _clientService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICategoryService categoryService, ITherapistService therapistService, IImageService imageService, IClientService clientService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _categoryService = categoryService;
            _therapistService = therapistService;
            _imageService = imageService;
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> Register(int id)
        {

            RegisterViewModel registerViewModel = new RegisterViewModel
            {
                RoleId = id,
                Categories = await _categoryService.GetAllAsync(),
                Universities = await _therapistService.GetAllUniversty(),
                Departments = await _therapistService.GetAllDepartments(),
                Titles = await _therapistService.GetAllTitles()
            };
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var imageName = registerViewModel.ProfilePic.FileName;
                int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                User user = new User
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    Gender = registerViewModel.Gender,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(registerViewModel.ProfilePic, "profilepics/therapists", ImageNameRepeatCount)
                    }
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (registerViewModel.RoleId == 0)
                    {
                        // Therapist kaydı
                        Therapist therapist = new Therapist
                        {
                            IsApproved = true,
                            UserId = user.Id,
                            Url = Jobs.GetUrl(registerViewModel.UserName)
                        };
                        if (registerViewModel.TitleId.HasValue)
                        {
                            therapist.TitleId = registerViewModel.TitleId.Value;
                        }
                        if (registerViewModel.UniversityId.HasValue)
                        {
                            if (registerViewModel.DepartmentId.HasValue)
                            {
                                therapist.Educations = new List<Education>
                                {
                                    new Education
                                    {
                                        UniversityId=registerViewModel.UniversityId,
                                        DepartmentId = registerViewModel.DepartmentId,

                                    }
                                }.ToList();
                            }
                            else
                            {
                                therapist.Educations = new List<Education>
                                {
                                    new Education
                                    {
                                        UniversityId=registerViewModel.UniversityId
                                    }
                                }.ToList();
                            }
                        }

                        //await _therapistService.CreateAsync(therapist);
                        if (registerViewModel.SelectedCategories != null)
                        {
                            await _therapistService.CreateTherapistWithFullDataAsync(therapist, registerViewModel.SelectedCategories);
                        }
                        else
                        {
                            await _therapistService.CreateAsync(therapist);
                        }
                        await _userManager.AddToRoleAsync(user, "Therapist");
                    }
                    else if (registerViewModel.RoleId == 1)
                    {
                        Client client = new Client
                        {
                            IsApproved = true,
                            UserId = user.Id,
                            Url = Jobs.GetUrl(registerViewModel.UserName)
                        };
                        await _clientService.CreateAsync(client);
                        await _userManager.AddToRoleAsync(user, "Client");

                    }
                    return RedirectToAction("Index", "Home");
                }

            }
            registerViewModel.Categories = await _categoryService.GetAllAsync();
            registerViewModel.Universities = await _therapistService.GetAllUniversty();
            registerViewModel.Titles = await _therapistService.GetAllTitles();
            registerViewModel.Departments = await _therapistService.GetAllDepartments();
            registerViewModel.RoleId = registerViewModel.RoleId;
            return View(registerViewModel);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!");
            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> ClientManage(string id)
        {
            string userName = id;
            if (String.IsNullOrEmpty(userName))
            {
                return NotFound();
            }
            var client = await _clientService.GetClientByUserName(userName);
            var user = await _userManager.FindByNameAsync(userName);
            if (user==null)
            {
                return NotFound();
            }
            user.Image = await _imageService.GetImageByUserIdAsync(client.UserId);
            var clientManageViewModel = new ClientManageViewModel
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
                ProfilPictureUrl = user.Image.Url,
                Address = user.Address,
            };
            return View(clientManageViewModel);

            



            return View();
        }
    }
}

