using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Producers : ShopHelper
    {
        [Key]
        public int IdProducer { get; set; }

        //Kategoria
        [Display(Name = "Kategoria")]
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Categories Category { get; set; }

    }
}
