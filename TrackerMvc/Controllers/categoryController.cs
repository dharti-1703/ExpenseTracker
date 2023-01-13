using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TrackerMvc.Models;

namespace TrackerMvc.Controllers
{
    public class categoryController : Controller
    {
        // GET: category
        public ActionResult Index()
        {
            IEnumerable<CategoryMvc> cat;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("category").Result;
            cat = response.Content.ReadAsAsync<IEnumerable<CategoryMvc>>().Result;
            return View(cat);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new CategoryMvc());
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.GetAsync("category/" + id.ToString()).Result;
                return View(respone.Content.ReadAsAsync<CategoryMvc>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(CategoryMvc ex)
        {
            if (ex.CategoryId == 0)
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PostAsJsonAsync("category", ex).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage respone = GlobalVariables.WebApiClient.PutAsJsonAsync("category/" + ex.CategoryId, ex).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("index");

        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage respone = GlobalVariables.WebApiClient.DeleteAsync("category/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("index");
        }

    }
}