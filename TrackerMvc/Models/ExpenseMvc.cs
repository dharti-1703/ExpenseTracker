using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrackerWebApi.Models;

namespace TrackerMvc.Models
{
    public class ExpenseMvc
    {
        public int ExpenseId { get; set; }
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        public string ExpenseTitle { get; set; }
        public string Description { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        public int Amount { get; set; }


        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
        public string NameCategory { get; set; }

        public virtual category category { get; set; }
    }
}