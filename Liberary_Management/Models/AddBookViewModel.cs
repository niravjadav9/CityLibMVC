using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liberary_Management.Models
{
    public class AddBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string isbn { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Publisher")]
        public List<SelectListItem> publisher { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string author { get; set; }
        
        [Required]
        [Display(Name = "Publication Date")]
        public DateTime publicationDate{ get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string branchName { get; set; }

        [Required]
        public string branchid { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }
    }
}