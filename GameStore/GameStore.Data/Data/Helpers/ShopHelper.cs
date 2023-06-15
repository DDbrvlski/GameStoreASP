using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Helpers
{
    public class ShopHelper
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Czy aktywny?")]
        public bool IsActive { get; set; }
    }
}
