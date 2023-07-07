using GameStore.Data.Data.Account;
using GameStore.Data.Data.Helpers;
using GameStore.Data.Data.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Data.Data.Shop
{
    public class Rates
    {
        [Key]
        public int IdRate { get; set; }
        public string Rating { get; set; }
    }
}
