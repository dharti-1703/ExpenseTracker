using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerMvc.Models;

namespace TrackerMvc.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            IEnumerable<CategoryMvc> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("category").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<CategoryMvc>>().Result;
            ViewBag.category = cat;


            int exlimit;
            HttpResponseMessage re = GlobalVariables.WebApiClient.GetAsync("Data").Result;
            exlimit = re.Content.ReadAsAsync<int>().Result;
            ViewBag.limit = exlimit;


            IEnumerable<ExpenseMvc> ex;
            HttpResponseMessage r = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            ex = r.Content.ReadAsAsync<IEnumerable<ExpenseMvc>>().Result;
            return View(ex);
          
        }

        public ActionResult filter(int id)
        {

            HttpResponseMessage req = GlobalVariables.WebApiClient.GetAsync("Data/" + id.ToString()).Result;
            IEnumerable<ExpenseMvc> expenselist = new List<ExpenseMvc>();

            if (req.IsSuccessStatusCode)
            {
                var display = req.Content.ReadAsAsync<List<ExpenseMvc>>();
                expenselist = display.Result;
            }
            IEnumerable<CategoryMvc> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("category").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<CategoryMvc>>().Result;
            ViewBag.category = cat;


            int exlimit;
            HttpResponseMessage re = GlobalVariables.WebApiClient.GetAsync("Data").Result;
            exlimit = re.Content.ReadAsAsync<int>().Result;
            ViewBag.limit = exlimit;
            return View("Index", expenselist);
        }
    }
}