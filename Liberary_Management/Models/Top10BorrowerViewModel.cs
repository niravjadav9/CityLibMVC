using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Liberary_Management.Models
{
    public class Top10BorrowerViewModel
    {
        [Display(Name = "Reader Name")]
        public string readerName { get; set; }

        [Display(Name = "Total Books Borrowed")]
        public int? totalBook { get; set; }
    }
}