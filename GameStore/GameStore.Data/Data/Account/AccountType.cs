using GameStore.Data.Data.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class AccountType : BaseEntity
    {
        [Key]
        public int IdAccountType { get; set; }

        [Required(ErrorMessage = "Nazwa typu konta jest wymagana.")]
        public string Name { get; set; }
    }
}
