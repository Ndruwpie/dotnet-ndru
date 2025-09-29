using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. TAMBAHKAN KONFIGURASI AUTHENTICATION & COOKIE
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Halaman login jika user belum terotentikasi
        options.AccessDeniedPath = "/Home/Dashboard"; // Halaman jika akses ditolak
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Durasi login
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 2. TAMBAHKAN MIDDLEWARE AUTHENTICATION
// Penting: Posisinya harus setelah UseRouting() dan sebelum UseAuthorization()
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // Atur halaman default ke Login

app.Run();