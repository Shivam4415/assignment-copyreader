using Editor.App.Api.CustomResponse;
using Editor.Entity;
using Editor.Entity.Data;
using Editor.Entity.Enum;
using Editor.Entity.Exceptions;
using Editor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Editor.App.Controller
{
    [RoutePrefix("api/v1/editor")]
    public class EditorController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(string id, [FromBody]IEnumerable<Operation> ops)
        {
            try
            {


                if (ops == null)
                    throw new RequestForbidden(new ErrorResponse(ErrorResponseCode.InvalidRequestError, Messages.RequestForbidden));

                EditorServices.Add(ops.ToList(), Convert.ToInt32(id));

            }
            catch(RequestForbidden r)
            {
                throw ExceptionResponse.Forbidden(Request, r.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}