using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ParentPortalAPI.Models;

namespace ParentPortalAPI.Controllers
{
    public class AccountGroupsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AccountGroups
        public IQueryable<AccountGroup> GetAccountGroups()
        {
            //string teamName = User.Identity.GetGroupMembers();

            //IQueryable<AccountGroup> ag = db.AccountGroups.Where(
            //        e => e.Group.Name.Equals(teamName));
            //return ag;
            return db.AccountGroups;
        }

        // GET: api/AccountGroups/5
        [ResponseType(typeof(AccountGroup))]
        public async Task<IHttpActionResult> GetAccountGroup(string id)
        {
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            if (accountGroup == null)
            {
                return NotFound();
            }

            return Ok(accountGroup);
        }

        // PUT: api/AccountGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAccountGroup(string id, AccountGroup accountGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountGroup.AccountId)
            {
                return BadRequest();
            }

            db.Entry(accountGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountGroupExists(id))
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

        // POST: api/AccountGroups
        [ResponseType(typeof(AccountGroup))]
        public async Task<IHttpActionResult> PostAccountGroup(AccountGroup accountGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccountGroups.Add(accountGroup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountGroupExists(accountGroup.AccountId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = accountGroup.AccountId }, accountGroup);
        }

        // DELETE: api/AccountGroups/5
        [ResponseType(typeof(AccountGroup))]
        public async Task<IHttpActionResult> DeleteAccountGroup(string id)
        {
            AccountGroup accountGroup = await db.AccountGroups.FindAsync(id);
            if (accountGroup == null)
            {
                return NotFound();
            }

            db.AccountGroups.Remove(accountGroup);
            await db.SaveChangesAsync();

            return Ok(accountGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountGroupExists(string id)
        {
            return db.AccountGroups.Count(e => e.AccountId == id) > 0;
        }
    }
}