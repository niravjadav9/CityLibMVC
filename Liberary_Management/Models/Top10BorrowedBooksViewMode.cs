using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liberary_Management.Models
{
    public class Top10BorrowedBooksViewMode
    {
        public int? BookCount { get; set; }
        public int? BookId { get; set; }
        public string BookName { get; set; }
    }
}