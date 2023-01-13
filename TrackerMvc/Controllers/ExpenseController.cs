using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerMvc.Models;

namespace TrackerMvc.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult Index()
        {
            IEnumerable<ExpenseMvc> ex;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Expense").Result;
            ex = response.Content.ReadAsAsync<IEnumerable<ExpenseMvc>>().Result;
            return View(ex);

        }

        public List<CategoryMvc> Drop()
        {
            IEnumerable<CategoryMvc> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("category").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<CategoryMvc>>().Result;
            return cat.ToList();
            
        }
    
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.categoryselect = new SelectList(Drop(), "CategoryId", "CategoryName");
                return View(new ExpenseMvc());
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.GetAsync("Expense/" + id.ToString()).Result;
                ViewBag.categoryselect = new SelectList(Drop(), "CategoryId", "CategoryName");
                return View(respone.Content.ReadAsAsync<ExpenseMvc>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(ExpenseMvc ex)
        {
            if (ex.ExpenseId == 0)
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PostAsJsonAsync("Expense", ex).Result;
                ViewBag.categoryselect = new SelectList(Drop(), "CategoryId", "CategoryName");
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PutAsJsonAsync("Expense/" + ex.ExpenseId, ex).Result;
                ViewBag.categoryselect = new SelectList(Drop(), "CategoryId", "CategoryName");
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index","Dashboard");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage respone = GlobalVariables.WebApiClient.DeleteAsync("Expense/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index", "Dashboard");
        }

    }
}