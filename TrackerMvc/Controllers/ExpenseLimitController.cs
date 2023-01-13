using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerMvc.Models;

namespace TrackerMvc.Controllers
{
    public class ExpenseLimitController : Controller
    {
        // GET: ExpenseLimit
        public ActionResult Index()
        {
            IEnumerable<ExpenseLimitMvc> limit;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ExpenseLimit").Result;
            limit = response.Content.ReadAsAsync<IEnumerable<ExpenseLimitMvc>>().Result;
            return View(limit);
            
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ExpenseLimitMvc());
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.GetAsync("ExpenseLimit/" + id.ToString()).Result;
                return View(respone.Content.ReadAsAsync<ExpenseLimitMvc>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(ExpenseLimitMvc ex)
        {
            if (ex.ExpenseLimitId == 0)
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PostAsJsonAsync("ExpenseLimit", ex).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PutAsJsonAsync("ExpenseLimit/" + ex.ExpenseLimitId, ex).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage respone = GlobalVariables.WebApiClient.DeleteAsync("ExpenseLimit/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("index");
        }
    }
}