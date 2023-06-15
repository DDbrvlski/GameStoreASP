using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Publishers : ShopHelper
    {
        [Key]
        public int IdPublisher { get; set; }

        //Kategoria
        [Display(Name = "Kategoria")]
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Categories Category { get; set; }
    }
}
