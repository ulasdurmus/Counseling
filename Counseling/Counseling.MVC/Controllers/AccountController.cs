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
        public async Task<IActionResult> Register(int id=1)
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
                                therapist.Education =

                                    new Education
                                    {
                                        UniversityId = registerViewModel.UniversityId,
                                        DepartmentId = registerViewModel.DepartmentId,

                                    };

                            }
                            else
                            {
                                therapist.Education =

                                    new Education
                                    {
                                        UniversityId = registerViewModel.UniversityId
                                    };

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
            if (user == null)
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
        }
        [HttpPost]
        public async Task<IActionResult> ClientManage(ClientManageViewModel clientManageViewModel)
        {
            var user = await _userManager.FindByIdAsync(clientManageViewModel.UserId);
            var client = await _clientService.GetById(clientManageViewModel.ClientId);
            if (ModelState.IsValid)
            {
                bool logOut = (clientManageViewModel.UserName != user.UserName);
                user.UserName = clientManageViewModel.UserName;
                user.LastName = clientManageViewModel.LastName;
                user.Email = clientManageViewModel.Email;
                user.Gender = clientManageViewModel.Gender;
                user.DateOfBirth = clientManageViewModel.DateOfBirth;
                user.FirstName = clientManageViewModel.FirstName;
                user.Address = clientManageViewModel.Address;
                user.NormalizedName = (clientManageViewModel.FirstName + clientManageViewModel.LastName).ToUpper();
                user.PhoneNumber = clientManageViewModel.PhoneNumber;
                client.Url = Jobs.GetUrl(clientManageViewModel.UserName);
                if (clientManageViewModel.ProfilePic != null)
                {

                    var imageName = clientManageViewModel.ProfilePic.FileName;
                    int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                    user.Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(clientManageViewModel.ProfilePic, "profilepics/clients", ImageNameRepeatCount)
                    };
                }
                await _userManager.UpdateAsync(user);
                _clientService.Update(client);
                if (logOut)
                {
                    return RedirectToAction("Logout");
                }
                return RedirectToAction("Index", "Home");
            }
            return View(clientManageViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> TherapistManage(string id)
        {
            string userName = id;
            if (String.IsNullOrEmpty(userName))
            {
                return NotFound();
            }
            var therapist = await _therapistService.GetTherapistFullDataByUserName(userName);
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }
            user.Image = await _imageService.GetImageByUserIdAsync(therapist.UserId);
            var therapistManageViewModel = new TherapistManageViewModel
            {
                TherapistId = therapist.Id,
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
                SelectedCategories = therapist.TherapistCategories.Select(t => t.CategoryId).ToArray(),
                //Categories = therapist.TherapistCategories.
                EducationId = therapist.Education.Id,
                Education = new Education
                {
                    Id = therapist.EducationId,
                    Department = therapist.Education.Department,
                    University = therapist.Education.University,
                    DepartmentId = therapist.Education.DepartmentId,
                    UniversityId = therapist.Education.UniversityId,
                    StartedDate = therapist.Education.StartedDate,
                    EndedDate = therapist.Education.EndedDate
                },
                Universities = await _therapistService.GetAllUniversty(),
                Departments = await _therapistService.GetAllDepartments(),
                Categories = await _categoryService.GetAllAsync(),
                Certificates = await _therapistService.GetAllCertificates(),
                Titles = await _therapistService.GetAllTitles()

                
            };
            return View(therapistManageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> TherapistManage(TherapistManageViewModel therapistManageViewModel)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(therapistManageViewModel.UserId);
                var therapist = await _therapistService.GetTherapistFullDataByUserName(user.UserName);
                if (therapist == null)
                {
                    return NotFound();
                }
                bool logOut = (therapistManageViewModel.UserName != user.UserName);
                user.FirstName = therapistManageViewModel.FirstName;
                user.LastName=therapistManageViewModel.LastName;
                user.PhoneNumber = therapistManageViewModel.PhoneNumber;
                user.DateOfBirth = therapistManageViewModel.DateOfBirth;
                user.Address= therapistManageViewModel.Address;
                user.Email = therapistManageViewModel.Email;
                user.Gender = therapistManageViewModel.Gender;
                user.UserName = therapistManageViewModel.UserName;
                if (therapistManageViewModel.ProfilePic != null)
                {
                    var imageName = therapistManageViewModel.ProfilePic.FileName;
                    int ImageNameRepeatCount = _imageService.CheckImageName(imageName);
                    user.Image = new Image
                    {
                        IsApproved = true,
                        Url = Jobs.UploadImage(therapistManageViewModel.ProfilePic, "profilepics/therapists", ImageNameRepeatCount)
                    };
                    await _imageService.CretaeAsync(user.Image);
                }
                therapist.Description = therapistManageViewModel.Description;
                therapist.Url = Jobs.GetUrl(therapistManageViewModel.UserName);
                therapist.Education = new Education
                { 
                    UniversityId = therapistManageViewModel.UniversityId,
                    DepartmentId = therapistManageViewModel.DepartmentId,
                    EndedDate = therapistManageViewModel.Education.EndedDate,
                    StartedDate = therapistManageViewModel.Education.StartedDate,
                };
                if(therapistManageViewModel.CertificatePdf != null)
                {
                    therapist.Certificates.Add(new Certificate
                    {
                        Name = therapistManageViewModel.CertificateName,
                        Description = therapistManageViewModel.CertificateDescription,
                        PdfUrl = Jobs.UploadPdf(therapistManageViewModel.CertificatePdf)
                    });
                }
                await _userManager.UpdateAsync(user);
                await _therapistService.UpdateTherapist(therapist, therapistManageViewModel.SelectedCategories);
                if (logOut)
                {
                    return RedirectToAction("logout");
                }
                return RedirectToAction("Index", "Home");

            }
            therapistManageViewModel.Categories = await _categoryService.GetAllAsync();
            therapistManageViewModel.Universities = await _therapistService.GetAllUniversty();
            therapistManageViewModel.Departments = await _therapistService.GetAllDepartments();
            therapistManageViewModel.Titles = await _therapistService.GetAllTitles();
            therapistManageViewModel.Certificates = await _therapistService.GetAllCertificates();
            return View(therapistManageViewModel);
        }

    }
}

