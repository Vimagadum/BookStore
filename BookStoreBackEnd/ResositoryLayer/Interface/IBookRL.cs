using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResositoryLayer.Interface
{
    public interface IBookRL
    {
        public AddBookModel AddBook(AddBookModel addBook);
        public UpdateBookModel UpdateBookDetails(UpdateBookModel updateBookModel);
        public UpdateBookModel GetBookByBookId(int bookId);
        public List<UpdateBookModel> GetAllBooks();
        public bool DeleteBook(int bookId);
    }
}
