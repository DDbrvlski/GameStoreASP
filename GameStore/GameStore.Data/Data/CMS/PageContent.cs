using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.CMS
{
    public class PageContent
    {
        [Key] //to co niżej jest kluczem podstawowym tabeli
        public int IdPageContent { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Link do do strony")] // ta nazwe pola bedzie widzial uzytkownik
        public string? Link { get; set; }

        [Display(Name = "Ikona")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string? Icon { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Tytuł")] // ta nazwe pola bedzie widzial uzytkownik
        public string? Title { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Treść")] // ta nazwe pola bedzie widzial uzytkownik
        public string Content { get; set; }

        [Display(Name = "Opis")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Description { get; set; }

        [Display(Name = "Sekcja")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Section { get; set; }

        [Display(Name = "Pozycja")] // ta nazwe pola bedzie widzial uzytkownik
        public int Position { get; set; }

        [Display(Name = "Strona")]
        public int? IdPage { get; set; }
        [ForeignKey("IdPage")]
        public virtual Page Page { get; set; }
    }
}
