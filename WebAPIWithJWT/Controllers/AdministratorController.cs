using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIWithJWT.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : ApiController
    {
        // GET: api/Administrator
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Administrator/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Administrator
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Administrator/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Administrator/5
        public void Delete(int id)
        {
        }
    }
}
