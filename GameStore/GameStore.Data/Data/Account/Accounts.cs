using GameStore.Data.Data.Shop;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class Accounts
    {
        [Key]
        public int IdAccount { get; set; }
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [MaxLength(50, ErrorMessage = "Nazwa użytkownika może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MaxLength(100, ErrorMessage = "Hasło może zawierać maksymalnie 100 znaków")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany")]
        [MaxLength(100, ErrorMessage = "Adres e-mail może zawierać maksymalnie 100 znaków")]
        [Display(Name = "Adres e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [MaxLength(50, ErrorMessage = "Imię może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MaxLength(50, ErrorMessage = "Nazwisko może zawierać maksymalnie 50 znaków")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [MaxLength(20, ErrorMessage = "Numer telefonu może zawierać maksymalnie 20 znaków")]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Data utworzenia konta jest wymagana")]
        [Display(Name = "Data utworzenia konta")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public int? IdAccountType { get; set; }
        [ForeignKey("IdAccountType")]
        public virtual AccountType AccountType { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<RatesProductsAccounts> RatesProductsAccounts { get; set; }
    }
}
