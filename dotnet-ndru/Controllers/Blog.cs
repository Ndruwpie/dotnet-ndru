using Microsoft.AspNetCore.Mvc;

namespace dotnet_ndru.Controllers
{
    public class Blog : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
