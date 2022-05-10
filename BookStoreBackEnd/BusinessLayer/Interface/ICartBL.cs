using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddBookToCart(CartModel cartModel, int userId);
        public List<DisplayCartModel> GetCartDetailsByUserid(int userId);
        public CartModel UpdateCart(int cartId, CartModel cartModel, int userId);
    }
}
