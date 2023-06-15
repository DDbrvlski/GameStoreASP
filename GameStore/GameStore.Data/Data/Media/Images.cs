using GameStore.Data.Data.Shop;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Media
{
    public class Images
    {
        [Key]
        public int IdImage { get; set; }

        [Display(Name = "Nazwa zdjecia")]
        public string? Name { get; set; }

        [Display(Name = "Pozycja")]
        public int? Position { get; set; }

        [Display(Name = "Zdjęcie")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "URL")]
        public string? Image { get; set; }

        [Display(Name = "Czy Aktywny")]
        public bool IsActive { get; set; }

        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Products? Product { get; set; }
    }
}