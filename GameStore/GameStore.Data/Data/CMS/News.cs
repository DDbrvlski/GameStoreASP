using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.CMS
{
    public class News
    {
        [Key] //to co niżej jest kluczem podstawowym tabeli
        public int IdNews { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")] // pole jest wymagane (nie może być null)
        [MaxLength(10, ErrorMessage = "Tytuł może zawierać max 10 znaków")]
        [Display(Name = "Tytuł zakładki")] // ta nazwe pola bedzie widzial uzytkownik
        public string TitleLink { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")] // pole jest wymagane (nie może być null)
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 10 znaków")]
        [Display(Name = "Tytuł strony")] // ta nazwe pola bedzie widzial uzytkownik
        public string Title { get; set; }

        [Display(Name = "Treść")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Content { get; set; }

        [Display(Name = "Pozycja")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Position { get; set; }
    }
}
