using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class UpdateBookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
        public int DiscountPrice { get; set; }
        public int ActualPrice { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
        public int BookQuantity { get; set; }
    }
}
