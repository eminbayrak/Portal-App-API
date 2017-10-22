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
using ParentPortalAPI.Models.Data;

namespace ParentPortalAPI.Controllers.ApiControllers
{
    public class AuthenticationController : ApiController
    {
        private ParentPortalApiContext db = new ParentPortalApiContext();

        // GET: api/Authentication
        public IQueryable<AuthToken> GetAuthTokens()
        {
            return db.AuthTokens;
        }

        // GET: api/Authentication/5
        [ResponseType(typeof(AuthToken))]
        public IHttpActionResult GetAuthToken(int id)
        {
            AuthToken authToken = db.AuthTokens.Find(id);
            if (authToken == null)
            {
                return NotFound();
            }

            return Ok(authToken);
        }

        // PUT: api/Authentication/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthToken(int id, AuthToken authToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authToken.Id)
            {
                return BadRequest();
            }

            db.Entry(authToken).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthTokenExists(id))
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

        // POST: api/Authentication
        [ResponseType(typeof(AuthToken))]
        public IHttpActionResult PostAuthToken(AuthToken authToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AuthTokens.Add(authToken);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authToken.Id }, authToken);
        }

        // DELETE: api/Authentication/5
        [ResponseType(typeof(AuthToken))]
        public IHttpActionResult DeleteAuthToken(int id)
        {
            AuthToken authToken = db.AuthTokens.Find(id);
            if (authToken == null)
            {
                return NotFound();
            }

            db.AuthTokens.Remove(authToken);
            db.SaveChanges();

            return Ok(authToken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthTokenExists(int id)
        {
            return db.AuthTokens.Count(e => e.Id == id) > 0;
        }
    }
}