using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManUI.Controllers
{
    public class UIMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientUserCount()
        {
            return View();
        }
    }
}
