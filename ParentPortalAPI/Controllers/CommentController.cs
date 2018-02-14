using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParentPortalAPI.Controllers
{
#if (!DEBUG)
    [Authorize]
#endif
    public class CommentController : ApiController
    {
        // GET: api/Discussion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Discussion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Discussion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Discussion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Discussion/5
        public void Delete(int id)
        {
        }
    }
}
