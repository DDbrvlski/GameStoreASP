using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Products
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa może zawierać max 30 znaków")]
        [Display(Name = "Nazwa produktu")]
        public string Name { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Czy Aktywny")]
        public bool IsActive { get; set; }
        
        //Kategoria
        [Display(Name = "Kategoria")]
        public int? IdCategory { get; set; }
        [ForeignKey ("IdCategory")]
        public virtual Categories Category { get; set; }

        //Platforma
        [Display(Name = "Platforma")]
        public int? IdPlatform { get; set; }
        [ForeignKey("IdPlatform")]
        public virtual Platforms Platform { get; set; }

        //Wydawca
        [Display(Name = "Wydawca")]
        public int? IdPublisher { get; set; }
        [ForeignKey("IdPublisher")]
        public virtual Publishers Publisher { get; set; }

        //Producent
        [Display(Name = "Producent")]
        public int? IdProducer { get; set; }
        [ForeignKey("IdProducer")]
        public virtual Producers Producer { get; set; }

        //Typ
        [Display(Name = "Typ")]
        public int? IdTypesOfProducts { get; set; }
        [ForeignKey("IdTypesOfProducts")]
        public virtual TypesOfProducts TypeOfProduct { get; set; }

        //Zdjecia
        public int? IdImage { get; set; }
        [ForeignKey("IdImage")]
        public virtual Images Image { get; set; }


        //Oceny
        public virtual ICollection<RatesProductsAccounts> RatesProductsAccounts { get; set; }
    }
}
