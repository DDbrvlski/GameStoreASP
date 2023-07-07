using GameStore.Data.Data.Shop;

namespace GameStore.PortalWWW.Models.Shop
{
    public class CartDetails
    {
        public List<CartElement> CartElements { get; set; }
        public decimal FullPrice { get; set; }
    }
}
