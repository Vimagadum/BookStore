using BusinessLayer.Interface;
using CommonLayer.Model;
using ResositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL BookRL;


        public BookBL(IBookRL BookRL)
        {
            this.BookRL = BookRL;
        }
        public AddBookModel AddBook(AddBookModel addBook)
        {
            try
            {
                return this.BookRL.AddBook(addBook);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                return this.BookRL.DeleteBook(bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BookModel> GetAllBooks()
        {
            try
            {
                return this.BookRL.GetAllBooks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BookModel GetBookByBookId(int bookId)
        {
            try
            {
                return this.BookRL.GetBookByBookId(bookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateBookModel UpdateBookDetails(int book_id, UpdateBookModel updateBookModel)
        {
            try
            {
                return this.BookRL.UpdateBookDetails(book_id, updateBookModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
