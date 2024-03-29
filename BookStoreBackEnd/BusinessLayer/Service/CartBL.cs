﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL CartRL;


        public CartBL(ICartRL CartRL)
        {
            this.CartRL = CartRL;
        }
        public CartModel AddBookToCart(CartModel cartModel, int userId)
        {
            try
            {
                return this.CartRL.AddBookToCart(cartModel, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCart(int cartId, int userId)
        {
            try
            {
                return this.CartRL.DeleteCart(cartId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DisplayCartModel> GetCartDetailsByUserid(int userId)
        {
            try
            {
                return this.CartRL.GetCartDetailsByUserid(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CartModel UpdateCart(int cartId, CartModel cartModel, int userId)
        {
            try
            {
                return this.CartRL.UpdateCart(cartId, cartModel, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
