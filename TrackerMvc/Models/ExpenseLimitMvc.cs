using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerMvc.Models
{
    public class ExpenseLimitMvc
    {
        public int ExpenseLimitId { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        public int TotalExpense { get; set; }


        [Required(ErrorMessage = "This Field is Required")]
        public int ExpenseLimit1 { get; set; }
    }
}