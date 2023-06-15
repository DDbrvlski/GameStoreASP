using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class OrderHistory
    {
        [Key]
        public int IdOrderHistory { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}
