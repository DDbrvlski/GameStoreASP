using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Helpers
{
    public class BaseEntity
    {
        [Display(Name = "Data dodania")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Data zmodyfikowania")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
