using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerMvc.Models
{
    public class CategoryMvc
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public int CategoryLimit { get; set; }
        public Nullable<int> AvailableAmount { get; set; }

    }
}