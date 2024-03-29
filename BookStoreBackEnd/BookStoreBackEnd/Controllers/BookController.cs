﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        private readonly IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        //Api Adding Book
        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddBook(AddBookModel addbook)
        {
            try
            {
                var book = this.bookBL.AddBook(addbook);
                if (book != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfully Book Added", Response = book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "UnSuccessfull Adding Book" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateBookDetails(int book_id, UpdateBookModel updateBookModel)
        {
            try
            {
                var Book = this.bookBL.UpdateBookDetails(book_id, updateBookModel);
                if (Book != null)
                {
                    return this.Ok(new { Success = true, message = "Book Deatials Updated successfully", Response = Book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Error! failed to update Books" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get/{bookId}")]
        public IActionResult GetBookByBookId(int bookId)
        {
            try
            {
                var book = this.bookBL.GetBookByBookId(bookId);
                if (book != null)
                {
                    return this.Ok(new { Success = true, message = "Successfully Books are displayed", Response = book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull Display the Books Enter Book Id again!!" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpGet("Get")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var allbooks = this.bookBL.GetAllBooks();
                if (allbooks != null)
                {
                    return this.Ok(new { Success = true, message = "All Book Details Fetched Sucessfully", Response = allbooks });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccessfull Display the Books" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                if (this.bookBL.DeleteBook(bookId))
                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to Delete Book Enter BOOk ID Again" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

    }
}
