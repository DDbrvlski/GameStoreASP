using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class Order : BaseEntity
    {
        [Key]
        public int IdOrder { get; set; }
        public int Amount { get; set; }
        public decimal FullPrice { get; set; }

        public int? IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public virtual Accounts Account { get; set; }
        public virtual ICollection<OrderElement> OrderElements { get; set; }

    }
}
