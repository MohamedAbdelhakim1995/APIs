using EcommerceApis.Models;

namespace EcommerceApis.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        public Cart GetByCustomerId(int id);
        public int InsertCartItem(CartItem cartItem);
        public CartItem GetCartItemById(int id);
        public int UpdateCartItem(int id, int Quantity);
        public int DeleteCartItem(int id);
    }
}
