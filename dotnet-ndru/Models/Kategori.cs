using System.ComponentModel.DataAnnotations;

namespace dotnet_ndru.Models
{
    public enum TipeKategori { Income, Expense }
    public enum StatusAktif { Active, NotActive }

    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        public TipeKategori Tipe { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; }

        [DataType(DataType.MultilineText)]
        public string Deskripsi { get; set; }

        [Required]
        public StatusAktif Status { get; set; }
    }
}