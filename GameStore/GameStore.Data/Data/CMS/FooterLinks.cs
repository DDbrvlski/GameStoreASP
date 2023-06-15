using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.CMS
{
    public class FooterLinks
    {
        [Key] //to co niżej jest kluczem podstawowym tabeli
        public int IdFooterLink { get; set; }

        [Display(Name = "Tytuł linku")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        [Required(ErrorMessage = "Pozycja jest wymagana")] // pole jest wymagane (nie może być null)
        public string Title { get; set; }

        [Display(Name = "Pozycja wyświetlania")] // ta nazwe pola bedzie widzial uzytkownik
        [Required(ErrorMessage = "Pozycja jest wymagana")] // pole jest wymagane (nie może być null)
        public int Position { get; set; }

        [Display(Name = "Link")] // ta nazwe pola bedzie widzial uzytkownik
        [Required(ErrorMessage = "Pozycja jest wymagana")] // pole jest wymagane (nie może być null)
        public string Link { get; set; }
    }
}
