using _81MY_SignalROrderMan.EntityLayer.Entities;
using _81MY_SignalROrderManUI.DTOs.IdentityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _81MY_SignalROrderManUI.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogInController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LogInDto logInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(logInDto.UserName, logInDto.Password, false, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "LogIn");
        }
    }
}
