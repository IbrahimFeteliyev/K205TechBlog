using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.dashboard.ViewModel;

namespace Web.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    public class AuthController : Controller
    {
        private readonly UserManager<K205User> _userManager;
        private readonly SignInManager<K205User> _signInManager;

        public AuthController(UserManager<K205User> userManager, SignInManager<K205User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM, string RetypePassword)
        {
            registerVM.PhotoUrl = "https://cdn.pixabay.com/photo/2021/12/21/08/29/owl-6884773_960_720.jpg";
            registerVM.About = "";

            if (ModelState.IsValid)
            {


                if (registerVM.Password != RetypePassword)
                {

                    ViewBag.Password = "Sifreler ust uste dusmur";
                    return View();

                }
                K205User user = new()
                {
                    UserName = registerVM.Username,
                    Name = registerVM.Name,
                    Surname = registerVM.Surname,
                    Email = registerVM.Email,
                    About = registerVM.About,
                    PhotoUrl = registerVM.PhotoUrl
                };

                IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View("Error");
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
