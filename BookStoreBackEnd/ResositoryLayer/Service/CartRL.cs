using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ResositoryLayer.Service
{
    public class CartRL : ICartRL 
    {
        private SqlConnection sqlConnection;

        private IConfiguration Configuration { get; }
        public CartRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        //Adding Cart Api
        public CartModel AddBookToCart(CartModel cartModel, int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddBookToCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.OrderQuantity);
                    cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
