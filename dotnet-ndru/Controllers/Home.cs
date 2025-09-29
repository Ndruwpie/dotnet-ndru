using Microsoft.AspNetCore.Mvc;

namespace dotnet_ndru.Controllers
{
    public class Home : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
