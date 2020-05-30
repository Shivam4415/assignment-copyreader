using Document.App.Api.CustomResponse;
using Document.App.App_Start;
using Document.Library.Entity;
using Document.Library.Entity.Exceptions;
using Document.Library.Globals.Enum;
using Document.Library.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Document.App.Api.v1
{
    [RoutePrefix("api/v1/editor")]
    public class EditorController : ApiController
    {
        [HttpGet]
        public IEnumerable<FileEditor> Get()
        {
            UserProfile _user = AuthManager.CurrentUser;
            if (_user == null)
                throw ExceptionResponse.Forbidden(Request, Messages.InvalidCredentials);

            try
            {
                IEnumerable<FileEditor> editors = EditorServices.GetAll(_user.Id);
                return editors;
            }
            catch (NotFound ex)
            {
                throw ExceptionResponse.NotFound(Request, ex.Message);
            }
            catch (RequestForbidden ex)
            {
                throw ExceptionResponse.Forbidden(Request, ex.Message);
            }
            catch (Exception ex)
            {
                throw ExceptionResponse.ServerErrorResponse(Request);
            }
        }

        [HttpGet]
        public IEnumerable<Operation> Get(string id)
        {
            UserProfile _user = AuthManager.CurrentUser;
            if (_user == null)
                throw ExceptionResponse.Forbidden(Request, Messages.InvalidCredentials);

            try
            {
                List<Operation> data = null; // EditorServices.GetData(_user.Id, int.Parse(id));
                return data.AsEnumerable<Operation>();
            }
            catch (NotFound ex)
            {
                throw ExceptionResponse.NotFound(Request, ex.Message);
            }
            catch (RequestForbidden ex)
            {
                throw ExceptionResponse.Forbidden(Request, ex.Message);
            }
            catch (Exception ex)
            {
                throw ExceptionResponse.ServerErrorResponse(Request);
            }
        }

        public FileEditor Post(FileEditor file)
        {

            UserProfile _user = AuthManager.CurrentUser;

            if (_user == null)
                throw ExceptionResponse.Forbidden(Request, Messages.InvalidCredentials);

            try
            {
                const string fileName = "Unititled";
                return EditorServices.Create(file?.Name ?? fileName, _user.Id);

            }
            catch (NotFound ex)
            {
                throw ExceptionResponse.NotFound(Request, ex.Message);
            }
            catch (RequestForbidden ex)
            {
                throw ExceptionResponse.Forbidden(Request, ex.Message);
            }
            catch (Exception)
            {
                throw ExceptionResponse.ServerErrorResponse(Request);
            }
        }

        // POST api/<controller>
        public void Post(string id, [FromBody]IEnumerable<Operation> ops)
        {
            try
            {


                if (ops == null)
                    throw new RequestForbidden(new ErrorResponse(ErrorResponseCode.InvalidRequestError, Messages.RequestForbidden));

                EditorServices.SegregateOperations(ops.ToList(), Convert.ToInt32(id));

            }
            catch (RequestForbidden r)
            {
                throw ExceptionResponse.Forbidden(Request, r.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}