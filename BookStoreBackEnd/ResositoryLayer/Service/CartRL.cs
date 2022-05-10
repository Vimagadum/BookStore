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
        //get cart by userid and cartid 
        public List<DisplayCartModel> GetCartDetailsByUserid(int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetCartByUserId", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<DisplayCartModel> cartmodel = new List<DisplayCartModel>();
                        while (reader.Read())
                        {
                            BookModel bookModel = new BookModel();
                            DisplayCartModel cartModel = new DisplayCartModel();

                            bookModel.BookName = reader["BookName"].ToString();
                            bookModel.AuthorName = reader["AuthorName"].ToString();
                            bookModel.ActualPrice = Convert.ToInt32(reader["ActualPrice"]);
                            bookModel.DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]);
                            bookModel.BookImage = reader["BookImage"].ToString();
                            cartModel.UserId = Convert.ToInt32(reader["UserId"]);
                            cartModel.BookId = Convert.ToInt32(reader["BookId"]);
                            cartModel.CartId = Convert.ToInt32(reader["CartId"]);
                            cartModel.OrderQuantity = Convert.ToInt32(reader["OrderQuantity"]);
                            cartModel.Bookmodel = bookModel;
                            cartmodel.Add(cartModel);
                        }

                        sqlConnection.Close();
                        return cartmodel;
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
        //Update cart
        public CartModel UpdateCart(int cartId, CartModel cartModel, int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.OrderQuantity);
                    cmd.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CartId", cartId);
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
        public bool DeleteCart(int cartId, int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
