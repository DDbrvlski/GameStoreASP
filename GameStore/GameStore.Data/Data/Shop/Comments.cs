using GameStore.Data.Data.Account;
using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Comments : BaseEntity
    {
        [Key]
        public int IdComment { get; set; }

        [Display(Name = "Tytuł komentarza")]
        public string CommentTitle { get; set; }

        [Display(Name = "Treść komentarza")]
        public string CommentContent { get; set; }


    }
}
