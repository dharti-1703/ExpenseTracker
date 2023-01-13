using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TrackerWebApi.Models;

namespace TrackerWebApi.Controllers
{
    public class DataController : ApiController
    {
        private ExpenseTrackerEntities db = new ExpenseTrackerEntities();

        [System.Web.Http.HttpGet]
        public int getData()
        {
            var data = db.ExpenseLimits.Where(x => x.ExpenseLimitId == 1).FirstOrDefault();
            return data.TotalExpense;

        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult filter(int id)
        {
            var data = db.Expenses.Where(x => x.CategoryId == id);
            return Ok (data);
        }

    }
}

