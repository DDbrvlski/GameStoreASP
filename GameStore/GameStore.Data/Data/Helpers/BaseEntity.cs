using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Helpers
{
    public class BaseEntity
    {
        [Required(ErrorMessage = "Data utworzenia jest wymagana")]
        [Display(Name = "Data dodania")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Data zmodyfikowania")]
        public DateTime ModifiedDate { get; set; }
    }
}
