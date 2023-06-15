using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class Orders
    {
        [Key]
        public int IdOrder { get; set; }

        public DateTime OrderDate { get; set; }

        public bool IsActive { get; set; }

        public int? IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public virtual Accounts Account { get; set; }

        public int? IdOrderHistory { get; set; }
        [ForeignKey("IdOrderHistory")]
        public virtual OrderHistory OrderHistory { get; set; }
    }
}
