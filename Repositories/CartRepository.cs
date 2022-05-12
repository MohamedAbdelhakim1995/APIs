using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApis.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly EcommerceEntity context;
        public CartRepository(EcommerceEntity _context)
        {
            context = _context;
        }

        public List<Cart> GetAll()
        {
            return context.cart.ToList();
        }

        public Cart GetById(int id)
        {
            return context.cart.Include(x => x.CartItems).FirstOrDefault(x => x.Id == id);
        }
        public Cart GetByCustomerId(int id)
        {
            return context.cart.FirstOrDefault(x => x.CustomerId == id.ToString());
        }

        public int Insert(Cart cart)
        {
            context.cart.Add(cart);
            return context.SaveChanges();
        }
        public int InsertCartItem(CartItem cartItem)
        {
            context.cartItem.Add(cartItem);
            return context.SaveChanges();
        }

        public int Update(int id, Cart cart)
        {
            Cart oldCart = GetById(id);
            if (oldCart != null)
            {
                oldCart.CustomerId = cart.CustomerId;



                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Cart oldCart = GetById(id);
            context.cart.Remove(oldCart);
            return context.SaveChanges();
        }
        public CartItem GetCartItemById(int id)
        {
            return context.cartItem.FirstOrDefault(c => c.Id == id);
        }

        public int UpdateCartItem(int id, int Quantity)
        {

            CartItem oldCartItem = GetCartItemById(id);
            if (oldCartItem != null)
            {
                oldCartItem.Quantity = Quantity;
                return context.SaveChanges();
            }
            return 0;
        }
        public int DeleteCartItem(int id)
        {
            context.cartItem.Remove(GetCartItemById(id));
            return context.SaveChanges();

            //CartItem oldCartItem = GetCartItemById(id);
            //if (oldCartItem != null)
            //{
            //    oldCartItem.Quantity = Quantity;
            //    return context.SaveChanges();
            //}
            //return 0;
        }
    }
}
