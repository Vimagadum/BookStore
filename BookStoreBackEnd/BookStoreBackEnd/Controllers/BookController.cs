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
        //private readonly IMemoryCache memoryCache;

        ////private readonly IDistributedCache distributedCache;

        //private readonly IBookBL bookBL;

        //public BookController(IBookBL bookBL, IMemoryCache memoryCache)
        //{
        //    this.bookBL = bookBL;
        //    this.memoryCache = memoryCache;

        //}
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
    }
}
