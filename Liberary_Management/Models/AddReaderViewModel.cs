using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Liberary_Management.Models
{
    public class AddReaderViewModel
    {
        [Display(Name = "Reader Id")]
        [Key]
        public string readerid { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.Text)]
        public string address { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string emailid { get; set; }
    }
}