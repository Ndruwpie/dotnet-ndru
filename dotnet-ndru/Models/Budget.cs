using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_ndru.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }

        [Required]
        [StringLength(150)]
        public string Nama { get; set; }

        [DataType(DataType.MultilineText)]
        public string Deskripsi { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Total Budget")]
        public decimal TotalBudget { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Repeat?")]
        public bool IsRepeat { get; set; }

        [Required]
        public StatusAktif Status { get; set; }
    }
}