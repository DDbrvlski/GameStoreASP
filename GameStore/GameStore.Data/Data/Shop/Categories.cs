using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Categories : BaseEntity
    {
        [Key]
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [MaxLength(15, ErrorMessage = "Nazwa może zawierać max 15 znaków")]
        [Display(Name = "Nazwa kategorii")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Czy aktywny")]
        public bool IsActive { get; set; }
    }
}
