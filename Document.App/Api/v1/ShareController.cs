using Document.Library.Entity;
using Document.Library.Globals.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Document.App.Api.v1
{
    [RoutePrefix("api/v1/share")]
    public class ShareController : ApiController
    {

        // GET api/<controller>/5
        public Dictionary<FileEditor, Permission> Get(int objectId)
        {
            return new Dictionary<FileEditor, Permission>();
        }

        // POST api/<controller>
        public void Post([FromBody]FileEditor editor, Dictionary<string, Permission> keyValuePairs)
        {

        }

        // PUT api/<controller>/5
        public void Put(int emailId, [FromBody]FileEditor editor, Permission type)
        {


        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}