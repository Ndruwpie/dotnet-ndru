using Microsoft.AspNetCore.Mvc;

namespace dotnet_ndru.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
