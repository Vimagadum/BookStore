using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResositoryLayer.Interface
{
    public interface ICartRL
    {
        public CartModel AddBookToCart(CartModel cartModel, int userId);
    }
}
