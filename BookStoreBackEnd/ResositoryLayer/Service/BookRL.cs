﻿using CommonLayer.Model;
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
        public UpdateBookModel UpdateBookDetails(int book_id,UpdateBookModel updateBookModel)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spUpdateBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", book_id);
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
        public BookModel GetBookByBookId(int bookId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetBookById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    sqlConnection.Open();
                    BookModel bookModel = new BookModel();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bookModel.BookId = Convert.ToInt32(reader["BookId"]);
                            bookModel.BookName = reader["BookName"].ToString();
                            bookModel.AuthorName = reader["AuthorName"].ToString();
                            bookModel.Rating = Convert.ToInt32(reader["Rating"]);
                            bookModel.RatingCount = Convert.ToInt32(reader["RatingCount"]);
                            bookModel.DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]);
                            bookModel.ActualPrice = Convert.ToInt32(reader["ActualPrice"]);
                            bookModel.Description = reader["Description"].ToString();
                            bookModel.BookImage = reader["BookImage"].ToString();
                            bookModel.BookQuantity = Convert.ToInt32(reader["BookQuantity"]);
                        }
                        sqlConnection.Close();
                        return bookModel;
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
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> bookModel = new List<BookModel>();
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spGetAllBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            bookModel.Add(new BookModel
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                BookName = reader["BookName"].ToString(),
                                AuthorName = reader["AuthorName"].ToString(),
                                Rating = Convert.ToInt32(reader["Rating"]),
                                RatingCount = Convert.ToInt32(reader["RatingCount"]),
                                DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]),
                                ActualPrice = Convert.ToInt32(reader["ActualPrice"]),
                                Description = reader["Description"].ToString(),
                                BookImage = reader["BookImage"].ToString(),
                                BookQuantity = Convert.ToInt32(reader["BookQuantity"])
                            });
                        }
                        sqlConnection.Close();
                        return bookModel;
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
        public bool DeleteBook(int bookId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStoreDataBase"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", bookId);
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

