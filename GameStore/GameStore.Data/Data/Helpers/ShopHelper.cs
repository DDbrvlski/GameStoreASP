using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Helpers
{
    public class ShopHelper : BaseEntity
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }
}
