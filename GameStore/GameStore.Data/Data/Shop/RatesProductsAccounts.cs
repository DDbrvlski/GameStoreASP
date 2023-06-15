using GameStore.Data.Data.Account;
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
    public class RatesProductsAccounts : BaseEntity
    {
        [Key]
        public int IdRatesProductsAccounts { get; set; }

        //Użytkownik
        [Display(Name = "Użytkownik")]
        public int? IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public virtual Accounts Account { get; set; }

        //Ocena
        [Display(Name = "Ocena")]
        public int? IdRate { get; set; }
        [ForeignKey("IdRate")]
        public virtual Rates Rate { get; set; }

        //Produkt
        [Display(Name = "Produkt")]
        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Products Product { get; set; }

        //Komentarz
        [Display(Name = "Komentarz")]
        public int? IdComment { get; set; }
        [ForeignKey("IdComment")]
        public virtual Comments Comment { get; set; }
    }
}
