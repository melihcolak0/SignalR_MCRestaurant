using _81MY_SignalROrderMan.EntityLayer.Entities;
using _81MY_SignalROrderManUI.DTOs.IdentityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _81MY_SignalROrderManUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            var appUser = new AppUser()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Mail,
                UserName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }
    }
}
