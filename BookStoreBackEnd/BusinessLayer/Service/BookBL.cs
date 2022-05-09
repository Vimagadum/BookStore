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

        public UpdateBookModel UpdateBookDetails(UpdateBookModel updateBookModel)
        {
            try
            {
                return this.BookRL.UpdateBookDetails(updateBookModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
