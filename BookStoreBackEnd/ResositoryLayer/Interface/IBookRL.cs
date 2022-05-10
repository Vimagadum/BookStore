﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResositoryLayer.Interface
{
    public interface IBookRL
    {
        public AddBookModel AddBook(AddBookModel addBook);
        public UpdateBookModel UpdateBookDetails(int book_id, UpdateBookModel updateBookModel);
        public BookModel GetBookByBookId(int bookId);
        public List<BookModel> GetAllBooks();
        public bool DeleteBook(int bookId);
    }
}
