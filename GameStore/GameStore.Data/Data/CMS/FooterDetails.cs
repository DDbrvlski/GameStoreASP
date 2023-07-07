using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.CMS
{
    public class FooterDetails : BaseEntity
    {
        [Key] //to co niżej jest kluczem podstawowym tabeli
        public int IdFooterDetail { get; set; }

        [Display(Name = "Tytuł")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Title { get; set; }

        [Display(Name = "Treść")] // ta nazwe pola bedzie widzial uzytkownik
        [Column(TypeName = "nvarchar(MAX)")] // określa jakiego typu to pole będzie w bazie danych
        public string Content { get; set; }
    }
}
