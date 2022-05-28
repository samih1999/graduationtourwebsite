using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace graduationtourwebsite.Models
{
    public class tour
    {
        public int Id { get; set; }


        [Display(Name = "From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        public string plces { get; set; }
        public string clientphone { get; set; }

        public string tourguides { get; set; }
        
        public string tourguidename { get; set; }
        public string tourguidephone { get; set; }
        public string custid { get; set; }
        public string customerid { get; set; }

        public string nameoncard { get; set; }
        public double balance { get; set; }
        public double price { get; set; }

        public int cvv { get; set; }

        
        public int cardnumber { get; set; }

        [Display(Name = "exp Date")]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime exp { get; set; }



        // public List<place> places { get; set; }
    }
}
