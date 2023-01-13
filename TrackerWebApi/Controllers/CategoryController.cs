using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TrackerWebApi.Models;

namespace TrackerWebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private ExpenseTrackerEntities db = new ExpenseTrackerEntities();

        // GET: api/Category
        public IQueryable<category> Getcategories()
        {
            return db.categories;
        }

        // GET: api/Category/5
        [ResponseType(typeof(category))]
        public IHttpActionResult Getcategory(int id)
        {
            category category = db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcategory(int id, category category)
        {
            

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!categoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Category
        [ResponseType(typeof(category))]
        public IHttpActionResult Postcategory(category category)
        {
            

            db.categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof(category))]
        public IHttpActionResult Deletecategory(int id)
        {
            category category = db.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.categories.Remove(category);

            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool categoryExists(int id)
        {
            return db.categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}