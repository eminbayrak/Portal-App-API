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
using Microsoft.AspNet.Identity;
using ParentPortalAPI.Models;

namespace ParentPortalAPI.Controllers
{
    public class AccountEventsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AccountEvents
        public IQueryable<AccountEvent> GetAccountEvents()
        {

            string userId = User.Identity.GetUserId();

            IQueryable<AccountEvent> ace = db.AccountEvents.Where(
                    ae => ae.AccountId.Equals(userId)
            );

            return ace;
        }

        // GET: api/AccountEvents/5
        [ResponseType(typeof(AccountEvent))]
        public IHttpActionResult GetAccountEvent(string id)
        {

            AccountEvent accountEvent = db.AccountEvents.Find(id);
            if (accountEvent == null)
            {
                return NotFound();
            }

            return Ok(accountEvent);
        }

        // PUT: api/AccountEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccountEvent(string id, AccountEvent accountEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountEvent.AccountId)
            {
                return BadRequest();
            }

            db.Entry(accountEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountEventExists(id))
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

        // POST: api/AccountEvents
        [ResponseType(typeof(AccountEvent))]
        public IHttpActionResult PostAccountEvent(AccountEvent accountEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountEvents.Add(accountEvent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountEventExists(accountEvent.AccountId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountEvent.AccountId }, accountEvent);
        }

        // DELETE: api/AccountEvents/5
        [ResponseType(typeof(AccountEvent))]
        public IHttpActionResult DeleteAccountEvent(string id)
        {
            AccountEvent accountEvent = db.AccountEvents.Find(id);
            if (accountEvent == null)
            {
                return NotFound();
            }

            db.AccountEvents.Remove(accountEvent);
            db.SaveChanges();

            return Ok(accountEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountEventExists(string id)
        {
            return db.AccountEvents.Count(e => e.AccountId == id) > 0;
        }
    }
}