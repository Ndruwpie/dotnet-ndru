using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication; // <-- Tambahkan ini
using Microsoft.AspNetCore.Authentication.Cookies; // <-- Tambahkan ini
using System.Security.Claims; // <-- Tambahkan ini (untuk login)
using System.Threading.Tasks; // <-- Tambahkan ini

namespace dotnet_ndru.Controllers
{
    public class AccountController : Controller
    {
        // ... (Method Login GET Anda sudah ada di sini)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Contoh method Login POST untuk membuat cookie
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // --- INI HANYA CONTOH LOGIKA LOGIN ---
            // Ganti dengan validasi ke database Anda
            if (email == "admin@example.com" && password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim("FullName", "Admin User"),
                    new Claim(ClaimTypes.Role, "Administrator"),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Dashboard", "Home");
            }
            // --- AKHIR CONTOH LOGIKA LOGIN ---

            // Jika login gagal
            ViewData["ErrorMessage"] = "Invalid email or password";
            return View();
        }


        // === INILAH METHOD LOGOUT ANDA ===
        [HttpGet] // Bisa juga [HttpPost] untuk keamanan lebih
        public async Task<IActionResult> Logout()
        {
            // Perintah ini menghapus cookie otentikasi dari browser
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Arahkan pengguna kembali ke halaman login setelah logout berhasil
            return RedirectToAction("Login", "Account");
        }
    }
}