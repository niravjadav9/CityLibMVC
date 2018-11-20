using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Liberary_Management.Models
{
    public class BranchViewModel
    {
        public int BrnahcId { get; set; }

        [Display(Name = "Branch Name")]
        public string Name { get; set; }

        [Display(Name = "Branch Location")]
        public string Location { get; set; }
    }
}