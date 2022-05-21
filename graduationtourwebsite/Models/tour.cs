using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace graduationtourwebsite.Models
{
    public class tour
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        // public List<place> places { get; set; }
    }
}
