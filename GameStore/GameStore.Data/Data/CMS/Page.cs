using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.CMS
{
    public class Page
    {
        [Key] //to co niżej jest kluczem podstawowym tabeli
        public int IdPage { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")] // pole jest wymagane (nie może być null)
        [MaxLength(20, ErrorMessage = "Tytuł może zawierać max 20 znaków")]
        [Display(Name = "Tytuł odnośnika do strony")] // ta nazwe pola bedzie widzial uzytkownik
        public string TitleLink { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")] // pole jest wymagane (nie może być null)
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 10 znaków")]
        [Display(Name = "Tytuł strony")] // ta nazwe pola bedzie widzial uzytkownik
        public string Title { get; set; }

        [Display(Name = "Treść")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Content { get; set; }

        [Display(Name = "Pozycja wyświetlania")] // ta nazwe pola bedzie widzial uzytkownik
        [Required(ErrorMessage = "Pozycja jest wymagana")] // pole jest wymagane (nie może być null)
        public int Position { get; set; }
    }
}
