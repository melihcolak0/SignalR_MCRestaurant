using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
