using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Account
{
    public class AccountType
    {
        [Key]
        public int IdAccountType { get; set; }

        [Required(ErrorMessage = "Nazwa typu konta jest wymagana.")]
        public string Name { get; set; }
    }
}
