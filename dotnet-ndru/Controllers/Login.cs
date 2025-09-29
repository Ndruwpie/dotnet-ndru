using Microsoft.AspNetCore.Mvc;


namespace dotnet_ndru.Controllers
{

    public class Login : Controller
    {

        public IActionResult login()
        {

            return View();
        }
    }
}
