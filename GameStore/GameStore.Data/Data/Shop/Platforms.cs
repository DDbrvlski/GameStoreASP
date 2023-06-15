using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Platforms : ShopHelper
    {
        [Key]
        public int IdPlatform { get; set; }

        //Kategoria
        [Display(Name = "Kategoria")]
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Categories Category { get; set; }

    }
}
