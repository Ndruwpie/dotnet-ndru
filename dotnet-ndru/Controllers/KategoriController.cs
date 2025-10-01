using dotnet_ndru.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Diperlukan untuk List
using System.Linq; // Diperlukan untuk FirstOrDefault, etc.

namespace dotnet_ndru.Controllers
{
    public class KategoriController : Controller
    {
        // 'static' membuat list ini bertahan selama aplikasi berjalan (data hilang saat aplikasi restart)
        private static List<Kategori> _kategoriDb = new List<Kategori>();
        private static int _nextId = 1; // Counter sederhana untuk ID unik

        // GET: /Kategori
        // Menampilkan daftar semua kategori
        public IActionResult Index()
        {
            // Mengurutkan data agar yang terbaru tampil di atas
            var model = _kategoriDb.OrderByDescending(k => k.Id).ToList();
            return View(model);
        }

        // GET: /Kategori/Details/5
        // Menampilkan detail satu kategori
        public IActionResult Details(int id)
        {
            var model = _kategoriDb.FirstOrDefault(k => k.Id == id);
            if (model == null)
            {
                return NotFound(); // Jika data dengan ID tsb tidak ditemukan
            }
            return View(model);
        }

        // GET: /Kategori/Create
        // Menampilkan form untuk menambah data baru
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Kategori/Create
        // Metode ini yang akan MENYIMPAN data dari form
        [HttpPost]
        [ValidateAntiForgeryToken] // Untuk keamanan dari serangan CSRF
        public IActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid) // Memeriksa apakah data yang dikirim valid sesuai model
            {
                kategori.Id = _nextId++; // Memberikan ID unik dan menaikkan counter
                _kategoriDb.Add(kategori); // INTI: Menambahkan data ke dalam list
                return RedirectToAction(nameof(Index)); // Arahkan kembali ke halaman daftar
            }
            return View(kategori); // Jika data tidak valid, tampilkan form lagi dengan pesan error
        }

        // GET: /Kategori/Edit/5
        // Menampilkan form untuk mengedit data yang sudah ada
        public IActionResult Edit(int id)
        {
            var model = _kategoriDb.FirstOrDefault(k => k.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: /Kategori/Edit/5
        // Metode ini yang akan MENGUPDATE data dari form edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var kategoriDiDb = _kategoriDb.FirstOrDefault(k => k.Id == id);
                if (kategoriDiDb != null)
                {
                    // INTI: Mengupdate properti objek yang ada di list
                    kategoriDiDb.Tipe = kategori.Tipe;
                    kategoriDiDb.Nama = kategori.Nama;
                    kategoriDiDb.Deskripsi = kategori.Deskripsi;
                    kategoriDiDb.Status = kategori.Status;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: /Kategori/Delete/5
        // Menampilkan halaman konfirmasi penghapusan
        public IActionResult Delete(int id)
        {
            var model = _kategoriDb.FirstOrDefault(k => k.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: /Kategori/Delete/5
        // Metode ini yang akan MENGHAPUS data
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kategori = _kategoriDb.FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                _kategoriDb.Remove(kategori); // INTI: Menghapus data dari list
            }
            return RedirectToAction(nameof(Index));
        }
    }
}