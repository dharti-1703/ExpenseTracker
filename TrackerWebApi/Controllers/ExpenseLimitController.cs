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
    public class ExpenseLimitController : ApiController
    {
        private ExpenseTrackerEntities db = new ExpenseTrackerEntities();

        // GET: api/ExpenseLimit
        public IQueryable<ExpenseLimit> GetExpenseLimits()
        {
            return db.ExpenseLimits;
        }

        // GET: api/ExpenseLimit/5
        [ResponseType(typeof(ExpenseLimit))]
        public IHttpActionResult GetExpenseLimit(int id)
        {
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            if (expenseLimit == null)
            {
                return NotFound();
            }

            return Ok(expenseLimit);
        }

        // PUT: api/ExpenseLimit/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExpenseLimit(int id, ExpenseLimit expenseLimit)
        {
            

            if (id != expenseLimit.ExpenseLimitId)
            {
                return BadRequest();
            }

            db.Entry(expenseLimit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseLimitExists(id))
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

        // POST: api/ExpenseLimit
        [ResponseType(typeof(ExpenseLimit))]
        public IHttpActionResult PostExpenseLimit(ExpenseLimit expenseLimit)
        {
            

            db.ExpenseLimits.Add(expenseLimit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expenseLimit.ExpenseLimitId }, expenseLimit);
        }

        // DELETE: api/ExpenseLimit/5
        [ResponseType(typeof(ExpenseLimit))]
        public IHttpActionResult DeleteExpenseLimit(int id)
        {
            ExpenseLimit expenseLimit = db.ExpenseLimits.Find(id);
            if (expenseLimit == null)
            {
                return NotFound();
            }

            db.ExpenseLimits.Remove(expenseLimit);
            db.SaveChanges();

            return Ok(expenseLimit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseLimitExists(int id)
        {
            return db.ExpenseLimits.Count(e => e.ExpenseLimitId == id) > 0;
        }
    }
}