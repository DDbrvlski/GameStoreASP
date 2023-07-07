using GameStore.Data.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Data.Data.Shop
{
    public class CartElement : BaseEntity
    {
        [Key]
        public int IdCartElement { get; set; }
        public string IdSession { get; set; }

        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Products? Product { get; set; }

        public int Amount { get; set; }

    }
}
