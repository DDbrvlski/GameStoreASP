using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class OrderElement : BaseEntity
    {
        [Key]
        public int IdOrderElement { get; set; }

        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int? IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }

        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Products Product { get; set; }
    }
}
