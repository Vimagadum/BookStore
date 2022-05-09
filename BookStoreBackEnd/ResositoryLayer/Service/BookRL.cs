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
    public class BookRL : IBookRL
    {
        private SqlConnection sqlConnection;
        private IConfiguration Configuration { get; }
        public BookRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        //Adding Book APi Method Calling Store Procedure
        public AddBookModel AddBook(AddBookModel addBook)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", addBook.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", addBook.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", addBook.Rating);
                    cmd.Parameters.AddWithValue("@RatingCount", addBook.RatingCount);
                    cmd.Parameters.AddWithValue("@DiscountPrice", addBook.DiscountPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", addBook.ActualPrice);
                    cmd.Parameters.AddWithValue("@Description", addBook.Description);
                    cmd.Parameters.AddWithValue("@BookImage", addBook.BookImage);
                    cmd.Parameters.AddWithValue("@BookQuantity", addBook.BookQuantity);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return addBook;
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
        public UpdateBookModel UpdateBookDetails(UpdateBookModel updateBookModel)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", updateBookModel.BookId);
                    cmd.Parameters.AddWithValue("@BookName", updateBookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", updateBookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", updateBookModel.Rating);
                    cmd.Parameters.AddWithValue("@RatingCount", updateBookModel.RatingCount);
                    cmd.Parameters.AddWithValue("@DiscountPrice", updateBookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", updateBookModel.ActualPrice);
                    cmd.Parameters.AddWithValue("@Description", updateBookModel.Description);
                    cmd.Parameters.AddWithValue("@BookImage", updateBookModel.BookImage);
                    cmd.Parameters.AddWithValue("@BookQuantity", updateBookModel.BookQuantity);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return updateBookModel;
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
